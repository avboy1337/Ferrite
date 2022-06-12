//  <auto-generated>
//  This file was auto-generated by the Ferrite TL Generator.
//  Please do not modify as all changes will be lost.
//  <auto-generated/>

using System.Buffers;
using System.Runtime.CompilerServices;
using Ferrite.Utils;

namespace Ferrite.TL.slim.mtproto;

public readonly unsafe struct dh_gen_ok : ITLObjectReader, ITLSerializable
{
    private readonly byte* _buff;
    private readonly IMemoryOwner<byte>? _memoryOwner;
    private dh_gen_ok(Span<byte> buffer, IMemoryOwner<byte> memoryOwner)
    {
        _buff = (byte*)Unsafe.AsPointer(ref buffer[0]);
        Length = buffer.Length;
        _memoryOwner = memoryOwner;
    }
    private dh_gen_ok(byte* buffer, in int length, IMemoryOwner<byte> memoryOwner)
    {
        _buff = buffer;
        Length = length;
        _memoryOwner = memoryOwner;
    }
    
    public Set_client_DH_params_answer GetAsSet_client_DH_params_answer()
    {
        return new Set_client_DH_params_answer(_buff, Length, _memoryOwner);
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
        var obj = new dh_gen_ok(data.Slice(offset, bytesRead), null);
        return obj;
    }
    public static ITLSerializable? Read(byte* buffer, in int length, in int offset, out int bytesRead)
    {
        bytesRead = GetOffset(4, buffer + offset, length);
        var obj = new dh_gen_ok(buffer + offset, bytesRead, null);
        return obj;
    }

    public static int GetRequiredBufferSize()
    {
        return 4 + 16 + 16 + 16;
    }
    public static dh_gen_ok Create(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> server_nonce, ReadOnlySpan<byte> new_nonce_hash1, MemoryPool<byte>? pool = null)
    {
        var length = GetRequiredBufferSize();
        var memory = pool != null ? pool.Rent(length) : MemoryPool<byte>.Shared.Rent(length);
        var obj = new dh_gen_ok(memory.Memory.Span[..length], memory);
        obj.SetConstructor(unchecked((int)0x3bcbf734));
        obj.Set_nonce(nonce);
        obj.Set_server_nonce(server_nonce);
        obj.Set_new_nonce_hash1(new_nonce_hash1);
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
    public ReadOnlySpan<byte> new_nonce_hash1 => new (_buff + GetOffset(3, _buff, Length), 16);
    private void Set_new_nonce_hash1(ReadOnlySpan<byte> value)
    {
        if(value.Length != 16)
        {
            return;
        }
        fixed (byte* p = value)
        {
            int offset = GetOffset(3, _buff, Length);
            Buffer.MemoryCopy(p, _buff + offset,
                Length - offset, 16);
        }
    }
    private static int GetOffset(int index, byte* buffer, int length)
    {
        int offset = 4;
        if(index >= 2) offset += 16;
        if(index >= 3) offset += 16;
        if(index >= 4) offset += 16;
        return offset;
    }
    public void Dispose()
    {
        _memoryOwner?.Dispose();
    }
}
