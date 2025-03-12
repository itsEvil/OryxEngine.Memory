using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryTools;
public class WriterBig(byte[] buffer) : IWriter
{
    private const int ByteLen = sizeof(byte);
    private const int BoolLen = sizeof(bool);
    private const int CharLen = sizeof(char);
    private const int ShortLen = sizeof(short);
    private const int IntLen = sizeof(int);
    private const int LongLen = sizeof(long);
    private const int FloatLen= sizeof(float);
    private const int DoubleLen= sizeof(double);
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
        var buffer = Buffer.AsSpan();
        buffer[Position] = value;
        Position += ByteLen;
    }
    /// <summary>
    /// Writes a char
    /// </summary>
    public void Write(char value)
    {
        if (Position + CharLen > Buffer.Length)
        {
            Position += CharLen;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }

        Span<byte> bytes = stackalloc byte[CharLen];
        if (!BitConverter.TryWriteBytes(bytes, value)) {
            Position += CharLen;
            var ex = new Exception($"Failed to write char bytes to span: {Position}, {Buffer.Length}");
            throw ex;
        }
        
        //Write it backwards cos its BIG Endian
        var buffer = Buffer.AsSpan();
        buffer[Position] = bytes[1];
        buffer[Position + 1] = bytes[0];
        Position += CharLen;
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
        
        var buffer = Buffer.AsSpan();
        buffer[Position] = value ? (byte)1 : (byte)0;
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
        
        var s = Buffer.AsSpan();
        BinaryPrimitives.WriteInt16BigEndian(s[Position..(Position + ShortLen)], value);
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
        
        var s = Buffer.AsSpan();
        BinaryPrimitives.WriteUInt16BigEndian(s[Position..(Position + ShortLen)], value);
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

        var s = Buffer.AsSpan();
        BinaryPrimitives.WriteInt32BigEndian(s[Position..(Position + IntLen)], value);
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
        
        var s = Buffer.AsSpan();
        BinaryPrimitives.WriteUInt32BigEndian(s[Position..(Position + IntLen)], value);
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
        
        var s = Buffer.AsSpan();
        BinaryPrimitives.WriteInt64BigEndian(s[Position..(Position + LongLen)], value);
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
        
        var s = Buffer.AsSpan();
        BinaryPrimitives.WriteUInt64BigEndian(s[Position..(Position + LongLen)], value);
        Position += LongLen;
    }
    /// <summary>
    /// Writes a float
    /// </summary>
    public void Write(float value)
    {
        if (Position + FloatLen > Buffer.Length)
        {
            Position += FloatLen;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }
        
        var s = Buffer.AsSpan();

        Span<byte> bytes = stackalloc byte[FloatLen];
        if (!BitConverter.TryWriteBytes(bytes, value))
        {
            Position += FloatLen;
            var ex = new Exception($"Writer failed to write float {value} to span! {Position}, {Buffer.Length}");
            throw ex;
        }
        
        s[Position] = bytes[3];
        s[Position + 1] = bytes[2];
        s[Position + 2] = bytes[1];
        s[Position + 3] = bytes[0];

        Position += IntLen;
    }
    /// <summary>
    /// Writes a double
    /// </summary>
    public void Write(double value)
    {
        if (Position + DoubleLen > Buffer.Length)
        {
            Position += DoubleLen;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }

        var buffer = Buffer.AsSpan();
        Span<byte> bytes = stackalloc byte[DoubleLen];
        if (!BitConverter.TryWriteBytes(bytes, value))
        {
            Position += DoubleLen;
            var ex = new Exception($"Writer failed to write double {value} to span! {Position}, {Buffer.Length}");
            throw ex;
        }
        
        buffer[Position] = bytes[7];
        buffer[Position + 1] = bytes[6];
        buffer[Position + 2] = bytes[5];
        buffer[Position + 3] = bytes[4];
        buffer[Position + 4] = bytes[3];
        buffer[Position + 5] = bytes[2];
        buffer[Position + 6] = bytes[1];
        buffer[Position + 7] = bytes[0];

        Position += DoubleLen;
    }
    /// <summary>
    /// Writes a string using ushort for length of the string
    /// </summary>
    public void Write(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        Write((ushort)bytes.Length);
        if (bytes.Length == 0)
            return;
        
        if (Position + bytes.Length > Buffer.Length)
        {
            Position += bytes.Length;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }

        var buffer = Buffer.AsSpan();
        bytes.CopyTo(buffer[Position..]);
        Position += bytes.Length;
    }
    /// <summary>
    /// Writes a string using int for the length of the string
    /// </summary>
    public void WriteUtf16(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        Write(bytes.Length);
        if (bytes.Length == 0)
            return;
        
        if (Position + bytes.Length > Buffer.Length)
        {
            Position += bytes.Length;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length}");
            throw ex;
        }

        var buffer = Buffer.AsSpan();
        var b = Buffer.AsSpan();
        bytes.CopyTo(b[Position..]);
        Position += bytes.Length;
    }
}