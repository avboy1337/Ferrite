//  <auto-generated>
//  This file was auto-generated by the Ferrite TL Generator.
//  Please do not modify as all changes will be lost.
//  <auto-generated/>

using System.Buffers;
using System.Runtime.CompilerServices;
using Ferrite.Utils;

namespace Ferrite.TL.slim.mtproto;

public readonly unsafe struct p_q_inner_data_temp_dc : ITLObjectReader, ITLSerializable
{
    private readonly byte* _buff;
    private readonly IMemoryOwner<byte>? _memoryOwner;
    private p_q_inner_data_temp_dc(Span<byte> buffer, IMemoryOwner<byte> memoryOwner)
    {
        _buff = (byte*)Unsafe.AsPointer(ref buffer[0]);
        Length = buffer.Length;
        _memoryOwner = memoryOwner;
    }
    private p_q_inner_data_temp_dc(byte* buffer, in int length, IMemoryOwner<byte> memoryOwner)
    {
        _buff = buffer;
        Length = length;
        _memoryOwner = memoryOwner;
    }
    
    public P_Q_inner_data GetAsP_Q_inner_data()
    {
        return new P_Q_inner_data(_buff, Length, _memoryOwner);
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
        bytesRead = GetOffset(9, (byte*)Unsafe.AsPointer(ref data[offset..][0]), data.Length);
        var obj = new p_q_inner_data_temp_dc(data.Slice(offset, bytesRead), null);
        return obj;
    }
    public static ITLSerializable? Read(byte* buffer, in int length, in int offset, out int bytesRead)
    {
        bytesRead = GetOffset(9, buffer + offset, length);
        var obj = new p_q_inner_data_temp_dc(buffer + offset, bytesRead, null);
        return obj;
    }

    public static int GetRequiredBufferSize(int len_pq, int len_p, int len_q)
    {
        return 4 + BufferUtils.CalculateTLBytesLength(len_pq) + BufferUtils.CalculateTLBytesLength(len_p) + BufferUtils.CalculateTLBytesLength(len_q) + 16 + 16 + 32 + 4 + 4;
    }
    public static p_q_inner_data_temp_dc Create(ReadOnlySpan<byte> pq, ReadOnlySpan<byte> p, ReadOnlySpan<byte> q, ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> server_nonce, ReadOnlySpan<byte> new_nonce, int dc, int expires_in, MemoryPool<byte>? pool = null)
    {
        var length = GetRequiredBufferSize(pq.Length, p.Length, q.Length);
        var memory = pool != null ? pool.Rent(length) : MemoryPool<byte>.Shared.Rent(length);
        var obj = new p_q_inner_data_temp_dc(memory.Memory.Span[..length], memory);
        obj.SetConstructor(unchecked((int)0x56fddf88));
        obj.Set_pq(pq);
        obj.Set_p(p);
        obj.Set_q(q);
        obj.Set_nonce(nonce);
        obj.Set_server_nonce(server_nonce);
        obj.Set_new_nonce(new_nonce);
        obj.Set_dc(dc);
        obj.Set_expires_in(expires_in);
        return obj;
    }
    public static int ReadSize(Span<byte> data, in int offset)
    {
        return GetOffset(9, (byte*)Unsafe.AsPointer(ref data[offset..][0]), data.Length);
    }

    public static int ReadSize(byte* buffer, in int length, in int offset)
    {
        return GetOffset(9, buffer + offset, length);
    }
    public ReadOnlySpan<byte> pq => BufferUtils.GetTLBytes(_buff, GetOffset(1, _buff, Length), Length);
    private void Set_pq(ReadOnlySpan<byte> value)
    {
        if(value.Length == 0)
        {
            return;
        }
        var offset = GetOffset(1, _buff, Length);
        var lenBytes = BufferUtils.WriteLenBytes(_buff, value, offset, Length);
        fixed (byte* p = value)
        {
            Buffer.MemoryCopy(p, _buff + offset + lenBytes,
                Length - offset, value.Length);
        }
    }
    public ReadOnlySpan<byte> p => BufferUtils.GetTLBytes(_buff, GetOffset(2, _buff, Length), Length);
    private void Set_p(ReadOnlySpan<byte> value)
    {
        if(value.Length == 0)
        {
            return;
        }
        var offset = GetOffset(2, _buff, Length);
        var lenBytes = BufferUtils.WriteLenBytes(_buff, value, offset, Length);
        fixed (byte* p = value)
        {
            Buffer.MemoryCopy(p, _buff + offset + lenBytes,
                Length - offset, value.Length);
        }
    }
    public ReadOnlySpan<byte> q => BufferUtils.GetTLBytes(_buff, GetOffset(3, _buff, Length), Length);
    private void Set_q(ReadOnlySpan<byte> value)
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
    public ReadOnlySpan<byte> nonce => new (_buff + GetOffset(4, _buff, Length), 16);
    private void Set_nonce(ReadOnlySpan<byte> value)
    {
        if(value.Length != 16)
        {
            return;
        }
        fixed (byte* p = value)
        {
            int offset = GetOffset(4, _buff, Length);
            Buffer.MemoryCopy(p, _buff + offset,
                Length - offset, 16);
        }
    }
    public ReadOnlySpan<byte> server_nonce => new (_buff + GetOffset(5, _buff, Length), 16);
    private void Set_server_nonce(ReadOnlySpan<byte> value)
    {
        if(value.Length != 16)
        {
            return;
        }
        fixed (byte* p = value)
        {
            int offset = GetOffset(5, _buff, Length);
            Buffer.MemoryCopy(p, _buff + offset,
                Length - offset, 16);
        }
    }
    public ReadOnlySpan<byte> new_nonce => new (_buff + GetOffset(6, _buff, Length), 32);
    private void Set_new_nonce(ReadOnlySpan<byte> value)
    {
        if(value.Length != 32)
        {
            return;
        }
        fixed (byte* p = value)
        {
            int offset = GetOffset(6, _buff, Length);
            Buffer.MemoryCopy(p, _buff + offset,
                Length - offset, 32);
        }
    }
    public ref readonly int dc => ref *(int*)(_buff + GetOffset(7, _buff, Length));
    private void Set_dc(in int value)
    {
        var p = (int*)(_buff + GetOffset(7, _buff, Length));
        *p = value;
    }
    public ref readonly int expires_in => ref *(int*)(_buff + GetOffset(8, _buff, Length));
    private void Set_expires_in(in int value)
    {
        var p = (int*)(_buff + GetOffset(8, _buff, Length));
        *p = value;
    }
    private static int GetOffset(int index, byte* buffer, int length)
    {
        int offset = 4;
        if(index >= 2) offset += BufferUtils.GetTLBytesLength(buffer, offset, length);
        if(index >= 3) offset += BufferUtils.GetTLBytesLength(buffer, offset, length);
        if(index >= 4) offset += BufferUtils.GetTLBytesLength(buffer, offset, length);
        if(index >= 5) offset += 16;
        if(index >= 6) offset += 16;
        if(index >= 7) offset += 32;
        if(index >= 8) offset += 4;
        if(index >= 9) offset += 4;
        return offset;
    }
    public void Dispose()
    {
        _memoryOwner?.Dispose();
    }
}
