//  <auto-generated>
//  This file was auto-generated by the Ferrite TL Generator.
//  Please do not modify as all changes will be lost.
//  <auto-generated/>

using System.Buffers;
using System.Runtime.CompilerServices;
using Ferrite.Utils;

namespace Ferrite.TL.slim.mtproto;

public readonly unsafe struct resPQ : ITLObjectReader, ITLSerializable
{
    private readonly byte* _buff;
    private readonly IMemoryOwner<byte>? _memoryOwner;
    private resPQ(Span<byte> buffer, IMemoryOwner<byte> memoryOwner)
    {
        _buff = (byte*)Unsafe.AsPointer(ref buffer[0]);
        Length = buffer.Length;
        _memoryOwner = memoryOwner;
    }
    private resPQ(byte* buffer, in int length, IMemoryOwner<byte> memoryOwner)
    {
        _buff = buffer;
        Length = length;
        _memoryOwner = memoryOwner;
    }
    
    public ResPQ GetAsResPQ()
    {
        return new ResPQ(_buff, Length, _memoryOwner);
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
        var obj = new resPQ(data.Slice(offset, bytesRead), null);
        return obj;
    }
    public static ITLSerializable? Read(byte* buffer, in int length, in int offset, out int bytesRead)
    {
        bytesRead = GetOffset(5, buffer + offset, length);
        var obj = new resPQ(buffer + offset, bytesRead, null);
        return obj;
    }

    public static int GetRequiredBufferSize(int len_pq, int len_server_public_key_fingerprints)
    {
        return 4 + 16 + 16 + BufferUtils.CalculateTLBytesLength(len_pq) + len_server_public_key_fingerprints;
    }
    public static resPQ Create(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> server_nonce, ReadOnlySpan<byte> pq, VectorOfLong server_public_key_fingerprints, MemoryPool<byte>? pool = null)
    {
        var length = GetRequiredBufferSize(pq.Length, server_public_key_fingerprints.Length);
        var memory = pool != null ? pool.Rent(length) : MemoryPool<byte>.Shared.Rent(length);
        var obj = new resPQ(memory.Memory.Span[..length], memory);
        obj.SetConstructor(unchecked((int)0x05162463));
        obj.Set_nonce(nonce);
        obj.Set_server_nonce(server_nonce);
        obj.Set_pq(pq);
        obj.Set_server_public_key_fingerprints(server_public_key_fingerprints.ToReadOnlySpan());
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
    public ReadOnlySpan<byte> nonce => new (_buff + GetOffset(1, _buff, Length), 16);
    private void Set_nonce(ReadOnlySpan<byte> value)
    {
        if(value.Length != 16)
        {
            return;
        }
        fixed (byte* p = value)
        {
            int offset = GetOffset(1, _buff, Length);
            Buffer.MemoryCopy(p, _buff + offset,
                Length - offset, 16);
        }
    }
    public ReadOnlySpan<byte> server_nonce => new (_buff + GetOffset(2, _buff, Length), 16);
    private void Set_server_nonce(ReadOnlySpan<byte> value)
    {
        if(value.Length != 16)
        {
            return;
        }
        fixed (byte* p = value)
        {
            int offset = GetOffset(2, _buff, Length);
            Buffer.MemoryCopy(p, _buff + offset,
                Length - offset, 16);
        }
    }
    public ReadOnlySpan<byte> pq => BufferUtils.GetTLBytes(_buff, GetOffset(3, _buff, Length), Length);
    private void Set_pq(ReadOnlySpan<byte> value)
    {
        if(value.Length == 0)
        {
            return;
        }
        var offset = GetOffset(3, _buff, Length);
        var lenBytes = BufferUtils.WriteLenBytes(_buff, value, offset, Length);
        fixed (byte* p = value)
        {
            Buffer.MemoryCopy(p, _buff + offset + lenBytes,
                Length - offset, value.Length);
        }
    }
    public VectorOfLong server_public_key_fingerprints => (VectorOfLong)VectorOfLong.Read(_buff, Length, GetOffset(4, _buff, Length), out var bytesRead);
    private void Set_server_public_key_fingerprints(ReadOnlySpan<byte> value)
    {
        fixed (byte* p = value)
        {
            int offset = GetOffset(4, _buff, Length);
            Buffer.MemoryCopy(p, _buff + offset,
                Length - offset, value.Length);
        }
    }
    private static int GetOffset(int index, byte* buffer, int length)
    {
        int offset = 4;
        if(index >= 2) offset += 16;
        if(index >= 3) offset += 16;
        if(index >= 4) offset += BufferUtils.GetTLBytesLength(buffer, offset, length);
        if(index >= 5) offset += VectorOfLong.ReadSize(buffer, length, offset);
        return offset;
    }
    public void Dispose()
    {
        _memoryOwner?.Dispose();
    }
}
