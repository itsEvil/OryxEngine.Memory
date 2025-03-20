using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Text;
// ReSharper disable once CheckNamespace
namespace OryxEngine.Memory;
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
    public void Write(byte value)
    {
        if (Position + ByteLen > Buffer.Length)
        {
            Position++;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }
        
        Buffer.AsSpan()[Position] = value;
        Position += ByteLen;
    }
    
    /// <summary>
    /// Writes a bool
    /// </summary>
    public void Write(bool value)
    {
        if (Position + BoolLen > Buffer.Length) {
            Position++;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }
        
        Buffer.AsSpan()[Position] = value ? (byte)1 : (byte)0;
        Position += BoolLen;
    }

    /// <summary>
    /// Writes a short
    /// </summary>
    public void Write(short value)
    {
        if (Position + ShortLen > Buffer.Length)
        {
            Position += ShortLen;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }
        
        BinaryPrimitives.WriteInt16BigEndian(GetSpan(ShortLen), value);
        Position += ShortLen;
    }
    /// <summary>
    /// Writes a ushort
    /// </summary>
    public void Write(ushort value)
    {
        if (Position + ShortLen > Buffer.Length)
        {
            Position += ShortLen;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }
        
        BinaryPrimitives.WriteUInt16BigEndian(GetSpan(ShortLen), value);
        Position += ShortLen;
    }
    /// <summary>
    /// Writes a int
    /// </summary>
    public void Write(int value)
    {
        if (Position + IntLen > Buffer.Length)
        {
            Position += IntLen;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }

        BinaryPrimitives.WriteInt32BigEndian(GetSpan(IntLen), value);
        Position += IntLen;
    }
    /// <summary>
    /// Writes a uint
    /// </summary>
    public void Write(uint value)
    {
        if (Position + IntLen > Buffer.Length)
        {
            Position += IntLen;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }
        
        BinaryPrimitives.WriteUInt32BigEndian(GetSpan(IntLen), value);
        Position += IntLen;
    }
    /// <summary>
    /// Writes a long
    /// </summary>
    public void Write(long value)
    {
        if (Position + LongLen > Buffer.Length)
        {
            Position += LongLen;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }
        
        BinaryPrimitives.WriteInt64BigEndian(GetSpan(LongLen), value);
        Position += LongLen;
    }
    /// <summary>
    /// Writes a ulong
    /// </summary>
    public void Write(ulong value)
    {
        if (Position + LongLen > Buffer.Length)
        {
            Position += LongLen;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }
        
        BinaryPrimitives.WriteUInt64BigEndian(GetSpan(LongLen), value);
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
    /// Writes a string using short for length of the string
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