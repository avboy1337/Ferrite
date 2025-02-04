﻿/*
 *   Project Ferrite is an Implementation Telegram Server API
 *   Copyright 2022 Aykut Alparslan KOC <aykutalparslan@msn.com>
 *
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU Affero General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU Affero General Public License for more details.
 *
 *   You should have received a copy of the GNU Affero General Public License
 *   along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Buffers;
using DotNext.Buffers;
using DotNext.IO;
using Ferrite.Data;
using Ferrite.Services;
using Ferrite.TL.mtproto;
using Ferrite.TL.ObjectMapper;
using Ferrite.Utils;

namespace Ferrite.TL.currentLayer.messages;
public class GetDialogs : ITLObject, ITLMethod
{
    private readonly SparseBufferWriter<byte> writer = new SparseBufferWriter<byte>(UnmanagedMemoryPool<byte>.Shared);
    private readonly ITLObjectFactory factory;
    private readonly IMessagesService _messages;
    private readonly IMapperContext _mapper;
    private bool serialized = false;
    public GetDialogs(ITLObjectFactory objectFactory, IMessagesService messages,
        IMapperContext mapper)
    {
        factory = objectFactory;
        _messages = messages;
        _mapper = mapper;
    }

    public int Constructor => -1594569905;
    public ReadOnlySequence<byte> TLBytes
    {
        get
        {
            if (serialized)
                return writer.ToReadOnlySequence();
            writer.Clear();
            writer.WriteInt32(Constructor, true);
            writer.Write<Flags>(_flags);
            if (_flags[1])
            {
                writer.WriteInt32(_folderId, true);
            }

            writer.WriteInt32(_offsetDate, true);
            writer.WriteInt32(_offsetId, true);
            writer.Write(_offsetPeer.TLBytes, false);
            writer.WriteInt32(_limit, true);
            writer.WriteInt64(_hash, true);
            serialized = true;
            return writer.ToReadOnlySequence();
        }
    }

    private Flags _flags;
    public Flags Flags
    {
        get => _flags;
        set
        {
            serialized = false;
            _flags = value;
        }
    }

    public bool ExcludePinned
    {
        get => _flags[0];
        set
        {
            serialized = false;
            _flags[0] = value;
        }
    }

    private int _folderId;
    public int FolderId
    {
        get => _folderId;
        set
        {
            serialized = false;
            _flags[1] = true;
            _folderId = value;
        }
    }

    private int _offsetDate;
    public int OffsetDate
    {
        get => _offsetDate;
        set
        {
            serialized = false;
            _offsetDate = value;
        }
    }

    private int _offsetId;
    public int OffsetId
    {
        get => _offsetId;
        set
        {
            serialized = false;
            _offsetId = value;
        }
    }

    private InputPeer _offsetPeer;
    public InputPeer OffsetPeer
    {
        get => _offsetPeer;
        set
        {
            serialized = false;
            _offsetPeer = value;
        }
    }

    private int _limit;
    public int Limit
    {
        get => _limit;
        set
        {
            serialized = false;
            _limit = value;
        }
    }

    private long _hash;
    public long Hash
    {
        get => _hash;
        set
        {
            serialized = false;
            _hash = value;
        }
    }

    public async Task<ITLObject> ExecuteAsync(TLExecutionContext ctx)
    {
        var result = factory.Resolve<RpcResult>();
        result.ReqMsgId = ctx.MessageId;
        var serviceResult = await _messages.GetDialogs(ctx.CurrentAuthKeyId,
            _offsetDate, _offsetId,
            _mapper.MapToDTO<InputPeer, InputPeerDTO>(_offsetPeer),
            _limit, _hash, ExcludePinned, _folderId);
        if (!serviceResult.Success)
        {
            var err = factory.Resolve<RpcError>();
            err.ErrorCode = serviceResult.ErrorMessage.Code;
            err.ErrorMessage = serviceResult.ErrorMessage.Message;
            result.Result = err;
        }
        else
        {
            var resp = factory.Resolve<DialogsImpl>();
            resp.Chats = factory.Resolve<Vector<Chat>>();
            foreach (var c in serviceResult.Result.Chats)
            {
                resp.Chats.Add(_mapper.MapToTLObject<Chat, ChatDTO>(c));
            }
            resp.Dialogs = factory.Resolve<Vector<Dialog>>();
            foreach (var d in serviceResult.Result.Dialogs)
            {
                resp.Dialogs.Add(_mapper.MapToTLObject<Dialog, DialogDTO>(d));
            }
            resp.Messages = factory.Resolve<Vector<Message>>();
            foreach (var m in serviceResult.Result.Messages)
            {
                resp.Messages.Add(_mapper.MapToTLObject<Message, MessageDTO>(m));
            }
            resp.Users = factory.Resolve<Vector<User>>();
            foreach (var u in serviceResult.Result.Users)
            {
                resp.Users.Add(_mapper.MapToTLObject<User, UserDTO>(u));
            }
            result.Result = resp;
        }

        return result;
    }

    public void Parse(ref SequenceReader buff)
    {
        serialized = false;
        _flags = buff.Read<Flags>();
        if (_flags[1])
        {
            _folderId = buff.ReadInt32(true);
        }

        _offsetDate = buff.ReadInt32(true);
        _offsetId = buff.ReadInt32(true);
        _offsetPeer = (InputPeer)factory.Read(buff.ReadInt32(true), ref buff);
        _limit = buff.ReadInt32(true);
        _hash = buff.ReadInt64(true);
    }

    public void WriteTo(Span<byte> buff)
    {
        TLBytes.CopyTo(buff);
    }
}