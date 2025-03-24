using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Text;
using OryxEngine.Optionals;

// ReSharper disable once CheckNamespace
namespace OryxEngine.Memory.Optionals;

public class ReaderLittle(byte[] buffer) : IReader
{
    private const int ByteLen = sizeof(byte);
    private const int BoolLen = sizeof(bool);
    private const int ShortLen = sizeof(short);
    private const int IntLen = sizeof(int);
    private const int LongLen = sizeof(long);
    
    public byte[] Buffer { get; } = buffer;
    public int Position { get; set; }
    public int Length { get; private set; }

    public void Reset(int length) {
        Length = length;
        Position = 0;
    }
    
    public void Clear() => Buffer.AsSpan().Clear();

    public Option<byte> PeekByte() {
        if (Position + ByteLen <= Length) 
            return Buffer[Position];
        
        return Errors.OutOfBoundsErrorByte;
    }

    public Option<byte> ReadByte() {
        if (Position + ByteLen <= Length) 
            return Buffer[Position++];
        
        Position++;
        return Errors.OutOfBoundsErrorByte;
    }
    
    public Option<bool> ReadBoolean()
    {
        if (Position + BoolLen <= Length) 
            return Buffer[Position++] == 1;
        
        Position++;
        return Errors.OutOfBoundsErrorBool;
    }

    public Option<short> ReadInt16()
    {
        if (Position + ShortLen > Length) 
        {
            Position += ShortLen;
            return Errors.OutOfBoundsErrorInt16;
        }

        var data = BinaryPrimitives.ReadInt16LittleEndian(GetSpan(ShortLen));
        Position += ShortLen;
        return data;
    }

    public Option<ushort> ReadUInt16()
    {
        if (Position + ShortLen > Length)
        {
            Position += ShortLen;
            return Errors.OutOfBoundsErrorUInt16;
        }

        var data = BinaryPrimitives.ReadUInt16LittleEndian(GetSpan(ShortLen));
        Position += ShortLen;
        return data;
    }

    public Option<int> ReadInt32()
    {
        if (Position + IntLen > Length)
        {
            Position += IntLen;
            return Errors.OutOfBoundsErrorInt32;
        }

        var data = BinaryPrimitives.ReadInt32LittleEndian(GetSpan(IntLen));
        Position += IntLen;
        return data;
    }

    public Option<uint> ReadUInt32()
    {
        if (Position + IntLen > Length)
        {
            Position += IntLen;
            return Errors.OutOfBoundsErrorUInt32;
        }

        var data = BinaryPrimitives.ReadUInt32LittleEndian(GetSpan(IntLen));
        Position += IntLen;
        return data;
    }

    public Option<long> ReadInt64()
    {
        if (Position + LongLen > Length)
        {
            Position += LongLen;
            return Errors.OutOfBoundsErrorInt64;
        }

        var data = BinaryPrimitives.ReadInt64LittleEndian(GetSpan(LongLen));
        Position += LongLen;
        return data;
    }

    public Option<ulong> ReadUInt64()
    {
        if (Position + LongLen > Length)
        {
            Position += LongLen;
            return Errors.OutOfBoundsErrorUInt64;
        }
        
        var data = BinaryPrimitives.ReadUInt64LittleEndian(GetSpan(LongLen));
        Position += LongLen;
        return data;
    }
    
    public Option<float> ReadFloat()
    {
        if (Position + IntLen > Length)
        {
            Position += IntLen;
            return Errors.OutOfBoundsErrorUInt32;
        }

        var data = BinaryPrimitives.ReadUInt32LittleEndian(GetSpan(IntLen));
        Position += IntLen;
        return BitConverter.UInt32BitsToSingle(data);
    }

    public Option<double> ReadDouble()
    {
        if (Position + LongLen > Length)
        {
            Position += LongLen;
            return Errors.OutOfBoundsErrorUInt64;
        }
        
        var data = BinaryPrimitives.ReadUInt64LittleEndian(GetSpan(LongLen));
        Position += LongLen;
        return BitConverter.UInt64BitsToDouble(data);
    }

    public Option<string> ReadString() 
    {
        if (Position + ShortLen > Length)
        {
            Position += ShortLen;
            return Errors.OutOfBoundsErrorUInt16;
        }

        var length = BinaryPrimitives.ReadUInt16LittleEndian(GetSpan(ShortLen));
        Position += ShortLen;

        if (length + Position > Length)
            return Errors.OutOfBoundsErrorString;
        
        if (length == 0)
            return "";

        var r = Encoding.UTF8.GetString(Buffer, Position, length);
        Position += length;
        return r;
    }

    public Option<string> ReadStringInt()
    {
        if (Position + IntLen > Length)
        {
            Position += IntLen;
            return Errors.OutOfBoundsErrorInt32;
        }

        var length = BinaryPrimitives.ReadInt32LittleEndian(GetSpan(IntLen));
        Position += IntLen;

        if (length + Position > Length)
            return Errors.OutOfBoundsErrorStringInt;
        
        if (length == 0)
            return "";
        
        var r = Encoding.UTF8.GetString(Buffer, Position, length);
        Position += length;
        return r;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Span<byte> GetSpan(int length) => Buffer.AsSpan(Position, length);
}