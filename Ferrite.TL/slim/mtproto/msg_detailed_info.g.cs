//  <auto-generated>
//  This file was auto-generated by the Ferrite TL Generator.
//  Please do not modify as all changes will be lost.
//  <auto-generated/>

using System.Buffers;
using System.Runtime.CompilerServices;
using Ferrite.Utils;

namespace Ferrite.TL.slim.mtproto;

public readonly unsafe struct msg_detailed_info : ITLObjectReader, ITLSerializable
{
    private readonly byte* _buff;
    private readonly IMemoryOwner<byte>? _memoryOwner;
    private msg_detailed_info(Span<byte> buffer, IMemoryOwner<byte> memoryOwner)
    {
        _buff = (byte*)Unsafe.AsPointer(ref buffer[0]);
        Length = buffer.Length;
        _memoryOwner = memoryOwner;
    }
    private msg_detailed_info(byte* buffer, in int length, IMemoryOwner<byte> memoryOwner)
    {
        _buff = buffer;
        Length = length;
        _memoryOwner = memoryOwner;
    }
    
    public MsgDetailedInfo GetAsMsgDetailedInfo()
    {
        return new MsgDetailedInfo(_buff, Length, _memoryOwner);
    }
    public ref readonly int Constructor => ref *(int*)_buff;

    private void SetConstructor(int constructor)
    {
        var p = (int*)_buff;
        *p = constructor;
    }
    public int Length { get; }
    public ReadOnlySpan<byte> ToReadOnlySpan() => new (_buff, Length);
    public static ITLSerializable? Read(Span<byte> data, in int offset, out int bytesRead)
    {
        bytesRead = GetOffset(5, (byte*)Unsafe.AsPointer(ref data[offset..][0]), data.Length);
        var obj = new msg_detailed_info(data.Slice(offset, bytesRead), null);
        return obj;
    }
    public static ITLSerializable? Read(byte* buffer, in int length, in int offset, out int bytesRead)
    {
        bytesRead = GetOffset(5, buffer + offset, length);
        var obj = new msg_detailed_info(buffer + offset, bytesRead, null);
        return obj;
    }

    public static int GetRequiredBufferSize()
    {
        return 4 + 8 + 8 + 4 + 4;
    }
    public static msg_detailed_info Create(long msg_id, long answer_msg_id, int bytes, int status, MemoryPool<byte>? pool = null)
    {
        var length = GetRequiredBufferSize();
        var memory = pool != null ? pool.Rent(length) : MemoryPool<byte>.Shared.Rent(length);
        var obj = new msg_detailed_info(memory.Memory.Span[..length], memory);
        obj.SetConstructor(unchecked((int)0x276d3ec6));
        obj.Set_msg_id(msg_id);
        obj.Set_answer_msg_id(answer_msg_id);
        obj.Set_bytes(bytes);
        obj.Set_status(status);
        return obj;
    }
    public static int ReadSize(Span<byte> data, in int offset)
    {
        return GetOffset(5, (byte*)Unsafe.AsPointer(ref data[offset..][0]), data.Length);
    }

    public static int ReadSize(byte* buffer, in int length, in int offset)
    {
        return GetOffset(5, buffer + offset, length);
    }
    public ref readonly long msg_id => ref *(long*)(_buff + GetOffset(1, _buff, Length));
    private void Set_msg_id(in long value)
    {
        var p = (long*)(_buff + GetOffset(1, _buff, Length));
        *p = value;
    }
    public ref readonly long answer_msg_id => ref *(long*)(_buff + GetOffset(2, _buff, Length));
    private void Set_answer_msg_id(in long value)
    {
        var p = (long*)(_buff + GetOffset(2, _buff, Length));
        *p = value;
    }
    public ref readonly int bytes => ref *(int*)(_buff + GetOffset(3, _buff, Length));
    private void Set_bytes(in int value)
    {
        var p = (int*)(_buff + GetOffset(3, _buff, Length));
        *p = value;
    }
    public ref readonly int status => ref *(int*)(_buff + GetOffset(4, _buff, Length));
    private void Set_status(in int value)
    {
        var p = (int*)(_buff + GetOffset(4, _buff, Length));
        *p = value;
    }
    private static int GetOffset(int index, byte* buffer, int length)
    {
        int offset = 4;
        if(index >= 2) offset += 8;
        if(index >= 3) offset += 8;
        if(index >= 4) offset += 4;
        if(index >= 5) offset += 4;
        return offset;
    }
    public void Dispose()
    {
        _memoryOwner?.Dispose();
    }
}
