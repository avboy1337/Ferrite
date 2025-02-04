// 
// Project Ferrite is an Implementation of the Telegram Server API
// Copyright 2022 Aykut Alparslan KOC <aykutalparslan@msn.com>
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
// 

using Ferrite.TL.slim;
using Ferrite.TL.slim.layer150.dto;
using MessagePack;

namespace Ferrite.Data.Repositories;

public class AppInfoRepository : IAppInfoRepository
{
    private readonly IKVStore _store;

    public AppInfoRepository(IKVStore store)
    {
        _store = store;
        _store.SetSchema(new TableDefinition("ferrite", "app_infos",
            new KeyDefinition("pk",
                new DataColumn { Name = "auth_key_id", Type = DataType.Long },
                new DataColumn { Name = "hash", Type = DataType.Long }),
            new KeyDefinition("by_hash",
                new DataColumn { Name = "hash", Type = DataType.Long })));
    }
    public bool PutAppInfo(TLAppInfo appInfo)
    {
        var info = appInfo.AsAppInfo();
        _store.Put(appInfo.AsSpan().ToArray(), info.AuthKeyId, info.Hash);
        return true;
    }

    public TLAppInfo? GetAppInfo(long authKeyId)
    {
        var appInfoBytes = _store.Get(authKeyId);
        return appInfoBytes != null ? new TLAppInfo(appInfoBytes, 0, appInfoBytes.Length) : null;
    }

    public TLAppInfo? GetAppInfoByAppHash(long hash)
    {
        var appInfoBytes = _store.GetBySecondaryIndex("by_hash", hash);
        return appInfoBytes != null ? new TLAppInfo(appInfoBytes, 0, appInfoBytes.Length) : null;
    }

    public long? GetAuthKeyIdByAppHash(long hash)
    {
        var appInfoBytes = _store.GetBySecondaryIndex("by_hash", hash);
        if (appInfoBytes == null) return null;
        return ((AppInfo)appInfoBytes.AsSpan()).AuthKeyId;
    }
}