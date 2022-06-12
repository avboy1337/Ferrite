//  <auto-generated>
//  This file was auto-generated by the Ferrite TL Generator.
//  Please do not modify as all changes will be lost.
//  <auto-generated/>

using System.Buffers;
using System.Runtime.CompilerServices;
using Ferrite.Utils;

namespace Ferrite.TL.slim.mtproto;

public readonly unsafe struct msgs_state_req : ITLObjectReader, ITLSerializable
{
    private readonly byte* _buff;
    private readonly IMemoryOwner<byte>? _memoryOwner;
    private msgs_state_req(Span<byte> buffer, IMemoryOwner<byte> memoryOwner)
    {
        _buff = (byte*)Unsafe.AsPointer(ref buffer[0]);
        Length = buffer.Length;
        _memoryOwner = memoryOwner;
    }
    private msgs_state_req(byte* buffer, in int length, IMemoryOwner<byte> memoryOwner)
    {
        _buff = buffer;
        Length = length;
        _memoryOwner = memoryOwner;
    }
    
    public MsgsStateReq GetAsMsgsStateReq()
    {
        return new MsgsStateReq(_buff, Length, _memoryOwner);
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
        bytesRead = GetOffset(2, (byte*)Unsafe.AsPointer(ref data[offset..][0]), data.Length);
        var obj = new msgs_state_req(data.Slice(offset, bytesRead), null);
        return obj;
    }
    public static ITLSerializable? Read(byte* buffer, in int length, in int offset, out int bytesRead)
    {
        bytesRead = GetOffset(2, buffer + offset, length);
        var obj = new msgs_state_req(buffer + offset, bytesRead, null);
        return obj;
    }

    public static int GetRequiredBufferSize(int len_msg_ids)
    {
        return 4 + len_msg_ids;
    }
    public static msgs_state_req Create(VectorOfLong msg_ids, MemoryPool<byte>? pool = null)
    {
        var length = GetRequiredBufferSize(msg_ids.Length);
        var memory = pool != null ? pool.Rent(length) : MemoryPool<byte>.Shared.Rent(length);
        var obj = new msgs_state_req(memory.Memory.Span[..length], memory);
        obj.SetConstructor(unchecked((int)0xda69fb52));
        obj.Set_msg_ids(msg_ids.ToReadOnlySpan());
        return obj;
    }
    public static int ReadSize(Span<byte> data, in int offset)
    {
        return GetOffset(2, (byte*)Unsafe.AsPointer(ref data[offset..][0]), data.Length);
    }

    public static int ReadSize(byte* buffer, in int length, in int offset)
    {
        return GetOffset(2, buffer + offset, length);
    }
    public VectorOfLong msg_ids => (VectorOfLong)VectorOfLong.Read(_buff, Length, GetOffset(1, _buff, Length), out var bytesRead);
    private void Set_msg_ids(ReadOnlySpan<byte> value)
    {
        fixed (byte* p = value)
        {
            int offset = GetOffset(1, _buff, Length);
            Buffer.MemoryCopy(p, _buff + offset,
                Length - offset, value.Length);
        }
    }
    private static int GetOffset(int index, byte* buffer, int length)
    {
        int offset = 4;
        if(index >= 2) offset += VectorOfLong.ReadSize(buffer, length, offset);
        return offset;
    }
    public void Dispose()
    {
        _memoryOwner?.Dispose();
    }
}
