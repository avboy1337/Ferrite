//  <auto-generated>
//  This file was auto-generated by the Ferrite TL Generator.
//  Please do not modify as all changes will be lost.
//  <auto-generated/>

using System.Buffers;
using System.Runtime.CompilerServices;
using Ferrite.Utils;

namespace Ferrite.TL.slim.mtproto;

public readonly unsafe struct new_session_created : ITLObjectReader, ITLSerializable
{
    private readonly byte* _buff;
    private readonly IMemoryOwner<byte>? _memoryOwner;
    private new_session_created(Span<byte> buffer, IMemoryOwner<byte> memoryOwner)
    {
        _buff = (byte*)Unsafe.AsPointer(ref buffer[0]);
        Length = buffer.Length;
        _memoryOwner = memoryOwner;
    }
    private new_session_created(byte* buffer, in int length, IMemoryOwner<byte> memoryOwner)
    {
        _buff = buffer;
        Length = length;
        _memoryOwner = memoryOwner;
    }
    
    public NewSession GetAsNewSession()
    {
        return new NewSession(_buff, Length, _memoryOwner);
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
        bytesRead = GetOffset(4, (byte*)Unsafe.AsPointer(ref data[offset..][0]), data.Length);
        var obj = new new_session_created(data.Slice(offset, bytesRead), null);
        return obj;
    }
    public static ITLSerializable? Read(byte* buffer, in int length, in int offset, out int bytesRead)
    {
        bytesRead = GetOffset(4, buffer + offset, length);
        var obj = new new_session_created(buffer + offset, bytesRead, null);
        return obj;
    }

    public static int GetRequiredBufferSize()
    {
        return 4 + 8 + 8 + 8;
    }
    public static new_session_created Create(long first_msg_id, long unique_id, long server_salt, MemoryPool<byte>? pool = null)
    {
        var length = GetRequiredBufferSize();
        var memory = pool != null ? pool.Rent(length) : MemoryPool<byte>.Shared.Rent(length);
        var obj = new new_session_created(memory.Memory.Span[..length], memory);
        obj.SetConstructor(unchecked((int)0x9ec20908));
        obj.Set_first_msg_id(first_msg_id);
        obj.Set_unique_id(unique_id);
        obj.Set_server_salt(server_salt);
        return obj;
    }
    public static int ReadSize(Span<byte> data, in int offset)
    {
        return GetOffset(4, (byte*)Unsafe.AsPointer(ref data[offset..][0]), data.Length);
    }

    public static int ReadSize(byte* buffer, in int length, in int offset)
    {
        return GetOffset(4, buffer + offset, length);
    }
    public ref readonly long first_msg_id => ref *(long*)(_buff + GetOffset(1, _buff, Length));
    private void Set_first_msg_id(in long value)
    {
        var p = (long*)(_buff + GetOffset(1, _buff, Length));
        *p = value;
    }
    public ref readonly long unique_id => ref *(long*)(_buff + GetOffset(2, _buff, Length));
    private void Set_unique_id(in long value)
    {
        var p = (long*)(_buff + GetOffset(2, _buff, Length));
        *p = value;
    }
    public ref readonly long server_salt => ref *(long*)(_buff + GetOffset(3, _buff, Length));
    private void Set_server_salt(in long value)
    {
        var p = (long*)(_buff + GetOffset(3, _buff, Length));
        *p = value;
    }
    private static int GetOffset(int index, byte* buffer, int length)
    {
        int offset = 4;
        if(index >= 2) offset += 8;
        if(index >= 3) offset += 8;
        if(index >= 4) offset += 8;
        return offset;
    }
    public void Dispose()
    {
        _memoryOwner?.Dispose();
    }
}
