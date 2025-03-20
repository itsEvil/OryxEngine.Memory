using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OryxEngine.Memory;
public class WriterLittle(byte[] buffer) : IWriter
{
    private const int ByteLen = sizeof(byte);
    private const int BoolLen = sizeof(byte);
    private const int CharLen = sizeof(char);
    private const int ShortLen = sizeof(short);
    private const int IntLen = sizeof(int);
    private const int LongLen = sizeof(long);
    private const int FloatLen = sizeof(float);
    private const int DoubleLen = sizeof(double);
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
    public void Write(byte value)
    {
        var start = Position;
        if (start + ByteLen > Buffer.Length)
        {
            Position++;
            var ex = new Exception($"Writer attempted to write out of bounds: {start}, {Buffer.Length}");
            throw ex;
        }
        
        Buffer.AsSpan()[start] = value;
        Position += BoolLen;
    } 
    
    /// <summary>
    /// Writes a bool
    /// </summary>
    public void Write(bool value) {
        var start = Position;
        if (start + BoolLen > Buffer.Length) {
            Position++;
            var ex = new Exception($"Writer attempted to write out of bounds: {start}, {Buffer.Length}");
            throw ex;
        }
        
        Buffer.AsSpan()[start] = value ? (byte)1 : (byte)0;
        Position += BoolLen;
    }

    /// <summary>
    /// Writes a short
    /// </summary>
    public void Write(short value)
    {
        var start = Position;
        if (start + ShortLen > Buffer.Length)
        {
            Position += ShortLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {start}, {Buffer.Length}");
            throw ex;
        }
        
        BinaryPrimitives.WriteInt16LittleEndian(GetSpan(ShortLen), value);
        Position += ShortLen;
    }
    /// <summary>
    /// Writes an ushort
    /// </summary>
    public void Write(ushort value)
    {
        var start = Position;
        if (start + ShortLen > Buffer.Length)
        {
            Position += ShortLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {start}, {Buffer.Length}");
            throw ex;
        }
        
        BinaryPrimitives.WriteUInt16LittleEndian(GetSpan(ShortLen), value);
        Position += ShortLen;
    }
    /// <summary>
    /// Writes an int
    /// </summary>
    public void Write(int value)
    {
        var start = Position;
        if (start + IntLen > Buffer.Length)
        {
            Position += IntLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {start}, {Buffer.Length}");
            throw ex;
        }

        BinaryPrimitives.WriteInt32LittleEndian(GetSpan(IntLen), value);
        Position += IntLen;
    }
    /// <summary>
    /// Writes a uint
    /// </summary>
    public void Write(uint value)
    {
        var start = Position;
        if (start + IntLen > Buffer.Length)
        {
            Position += IntLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }
        
        BinaryPrimitives.WriteUInt32LittleEndian(GetSpan(IntLen), value);
        Position += IntLen;
    }
    /// <summary>
    /// Writes a long
    /// </summary>
    public void Write( long value)
    {
        var start = Position;
        if (start + LongLen > Buffer.Length)
        {
            Position += LongLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }
        
        BinaryPrimitives.WriteInt64LittleEndian(GetSpan(LongLen), value);
        Position += LongLen;
    }
    /// <summary>
    /// Writes a ulong
    /// </summary>
    public void Write(ulong value)
    {
        var start = Position;
        if (start + LongLen > Buffer.Length)
        {
            Position += LongLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }

        BinaryPrimitives.WriteUInt64LittleEndian(GetSpan(LongLen), value);
        Position += LongLen;
    }
    /// <summary>
    /// Writes a float
    /// </summary>
    public void Write(float value) => Write(BitConverter.SingleToUInt32Bits(value));
    /// <summary>
    /// Writes a double
    /// </summary>
    public void Write(double value) => Write(BitConverter.DoubleToUInt64Bits(value));
    /// <summary>
    /// Writes a string using ushort for length of the string
    /// </summary>
    public void WriteString(ReadOnlySpan<char> value) {
        if (value.Length == 0) {
            Write((ushort)0);
            return;
        }
        
        if (!Encoding.UTF8.TryGetBytes(value, Buffer.AsSpan(Position + ShortLen), out var length))
            throw new ArgumentOutOfRangeException($"Writer failed to get bytes of: {value.ToString()} at: {Position}, written: {length}");
        
        Write((ushort)length);
        Position += length;
    }
    
    /// <summary>
    /// Writes a string using int for length of the string
    /// </summary>
    public void WriteStringInt(ReadOnlySpan<char> value) {
        if (value.Length == 0) {
            Write(0);
            return;
        }
        
        if (!Encoding.UTF8.TryGetBytes(value, Buffer.AsSpan(Position + IntLen), out var length))
            throw new ArgumentOutOfRangeException($"Writer failed to get bytes of: {value.ToString()} at: {Position}, written: {length}");
        
        Write(length);
        Position += length;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Span<byte> GetSpan(int length) => Buffer.AsSpan(Position, length);
}