using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Text;
using OryxEngine.Optionals;

// ReSharper disable once CheckNamespace
namespace OryxEngine.Memory.Optionals;
public class WriterBig(byte[] buffer) : IWriter
{
    private const int ByteLen = sizeof(byte);
    private const int BoolLen = sizeof(bool);
    private const int ShortLen = sizeof(short);
    private const int IntLen = sizeof(int);
    private const int LongLen = sizeof(long);
    public int Position { get; private set; }
    public byte[] Buffer { get; } = buffer;

    public void Reset()
    {
        Position = 0;
    }
    public void SetPosition(int position) => Position = position;
    /// <summary>
    /// Writes a byte
    /// </summary>
    public Option<bool> Write(byte value)
    {
        if (Position + ByteLen > Buffer.Length)
        {
            Position++;
            return Errors.OutOfBoundsErrorByte;
        }
        
        Buffer.AsSpan()[Position] = value;
        Position += ByteLen;
        return true;
    }
    
    /// <summary>
    /// Writes a bool
    /// </summary>
    public Option<bool> Write(bool value)
    {
        if (Position + BoolLen > Buffer.Length) {
            Position++;
            return Errors.OutOfBoundsErrorBool;
        }
        
        Buffer.AsSpan()[Position] = value ? (byte)1 : (byte)0;
        Position += BoolLen;
        return true;
    }

    /// <summary>
    /// Writes a short
    /// </summary>
    public Option<bool> Write(short value)
    {
        if (Position + ShortLen > Buffer.Length)
        {
            Position += ShortLen;
            return Errors.OutOfBoundsErrorInt16;
        }
        
        BinaryPrimitives.WriteInt16BigEndian(GetSpan(ShortLen), value);
        Position += ShortLen;
        return true;
    }
    /// <summary>
    /// Writes a ushort
    /// </summary>
    public Option<bool> Write(ushort value)
    {
        if (Position + ShortLen > Buffer.Length)
        {
            Position += ShortLen;
            return Errors.OutOfBoundsErrorUInt16;
        }
        
        BinaryPrimitives.WriteUInt16BigEndian(GetSpan(ShortLen), value);
        Position += ShortLen;
        return true;
    }
    /// <summary>
    /// Writes a int
    /// </summary>
    public Option<bool> Write(int value)
    {
        if (Position + IntLen > Buffer.Length)
        {
            Position += IntLen;
            return Errors.OutOfBoundsErrorInt32;
        }

        BinaryPrimitives.WriteInt32BigEndian(GetSpan(IntLen), value);
        Position += IntLen;
        return true;
    }
    /// <summary>
    /// Writes a uint
    /// </summary>
    public Option<bool> Write(uint value)
    {
        if (Position + IntLen > Buffer.Length)
        {
            Position += IntLen;
            return Errors.OutOfBoundsErrorUInt32;
        }
        
        BinaryPrimitives.WriteUInt32BigEndian(GetSpan(IntLen), value);
        Position += IntLen;
        return true;
    }
    /// <summary>
    /// Writes a long
    /// </summary>
    public Option<bool> Write(long value)
    {
        if (Position + LongLen > Buffer.Length)
        {
            Position += LongLen;
            return Errors.OutOfBoundsErrorInt64;
        }
        
        BinaryPrimitives.WriteInt64BigEndian(GetSpan(LongLen), value);
        Position += LongLen;
        return true;
    }
    /// <summary>
    /// Writes a ulong
    /// </summary>
    public Option<bool> Write(ulong value)
    {
        if (Position + LongLen > Buffer.Length)
        {
            Position += LongLen;
            return Errors.OutOfBoundsErrorUInt64;
        }
        
        BinaryPrimitives.WriteUInt64BigEndian(GetSpan(LongLen), value);
        Position += LongLen;
        return true;
    }
    /// <summary>
    /// Writes a float
    /// </summary>
    public Option<bool> Write(float value) => Write(BitConverter.SingleToUInt32Bits(value));
    /// <summary>
    /// Writes a double
    /// </summary>
    public Option<bool> Write(double value) => Write(BitConverter.DoubleToUInt64Bits(value));
    /// <summary>
    /// Writes a string using ushort for length of the string
    /// </summary>
    public Option<bool> WriteString(ReadOnlySpan<char> value) {
        if (value.Length == 0) {
            Write((ushort)0);
            return true;
        }

        if (!Encoding.UTF8.TryGetBytes(value, Buffer.AsSpan(Position + ShortLen), out var length))
            throw new ArgumentOutOfRangeException($"Writer failed to get bytes of: {value.ToString()} at: {Position}, written: {length}");
        
        Write((ushort)length);
        Position += length;
        return true;
    }
    
    /// <summary>
    /// Writes a string using short for length of the string
    /// </summary>
    public Option<bool> WriteStringInt(ReadOnlySpan<char> value) {
        if (value.Length == 0) {
            Write(0);
            return true;
        }

        if (!Encoding.UTF8.TryGetBytes(value, Buffer.AsSpan(Position + IntLen), out var length))
            throw new ArgumentOutOfRangeException($"Writer failed to get bytes of: {value.ToString()} at: {Position}, written: {length}");
        
        Write(length);
        Position += length;
        return true;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Span<byte> GetSpan(int length) => Buffer.AsSpan(Position, length);
}