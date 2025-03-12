using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Text;

namespace MemoryTools;
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
    public void Write(byte value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (Position + ByteLen > Buffer.Length)
        {
            Position++;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }
        var buffer = Buffer.AsSpan();
        buffer[Position++] = value;
    }    
    /// <summary> 
    /// Writes a char  
    /// </summary>
    public void Write(char value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (Position + CharLen > Buffer.Length)
        {
            Position += CharLen;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }

        Span<byte> bytes = stackalloc byte[CharLen];
        if (!BitConverter.TryWriteBytes(bytes, value)) {
            Position += CharLen;
            var ex = new Exception($"Failed to write char bytes to span: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }
        
        //Write it normally cos its Little Endian
        var buffer = Buffer.AsSpan();
        buffer[Position] = bytes[0];
        buffer[Position + 1] = bytes[1];
        Position += CharLen;
    }

    /// <summary>
    /// Writes a bool
    /// </summary>
    public void Write(bool value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) {
        if (Position + BoolLen > Buffer.Length) {
            Position++;
            var ex = new Exception($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }
        
        var buffer = Buffer.AsSpan();
        buffer[Position++] = value ? (byte)1 : (byte)0;
    }

    /// <summary>
    /// Writes a short
    /// </summary>
    public void Write(short value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (Position + ShortLen > Buffer.Length)
        {
            Position += ShortLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }
        var buffer = Buffer.AsSpan();
        BinaryPrimitives.WriteInt16LittleEndian(buffer[Position..(Position + ShortLen)], value);
        Position += ShortLen;
    }
    /// <summary>
    /// Writes an ushort
    /// </summary>
    public void Write(ushort value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (Position + ShortLen > Buffer.Length)
        {
            Position += ShortLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }
        var buffer = Buffer.AsSpan();
        BinaryPrimitives.WriteUInt16LittleEndian(buffer[Position..(Position + ShortLen)], value);
        Position += ShortLen;
    }
    /// <summary>
    /// Writes an int
    /// </summary>
    public void Write(int value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (Position + IntLen > Buffer.Length)
        {
            Position += IntLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }

        var buffer = Buffer.AsSpan();
        BinaryPrimitives.WriteInt32LittleEndian(buffer[Position..(Position + IntLen)], value);
        Position += IntLen;
    }
    /// <summary>
    /// Writes a uint
    /// </summary>
    public void Write(uint value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (Position + IntLen > Buffer.Length)
        {
            Position += IntLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }
        var buffer = Buffer.AsSpan();
        BinaryPrimitives.WriteUInt32LittleEndian(buffer[Position..(Position + IntLen)], value);
        Position += IntLen;
    }
    /// <summary>
    /// Writes a long
    /// </summary>
    public void Write( long value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (Position + LongLen > Buffer.Length)
        {
            Position += LongLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }
        var buffer = Buffer.AsSpan();
        BinaryPrimitives.WriteInt64LittleEndian(buffer[Position..(Position + LongLen)], value);
        Position += LongLen;
    }
    /// <summary>
    /// Writes a ulong
    /// </summary>
    public void Write(ulong value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (Position + LongLen > Buffer.Length)
        {
            Position += LongLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }
        var buffer = Buffer.AsSpan();
        BinaryPrimitives.WriteUInt64LittleEndian(buffer[Position..(Position + LongLen)], value);
        Position += LongLen;
    }
    /// <summary>
    /// Writes a float
    /// </summary>
    public void Write(float value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (Position + FloatLen > Buffer.Length)
        {
            Position += FloatLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }
        var buffer = Buffer.AsSpan();       
        Span<byte> bytes = stackalloc byte[FloatLen];
        if (!BitConverter.TryWriteBytes(bytes, value))
        {
            Position += FloatLen;
            var ex = new Exception($"Writer failed to write float {value} to span! {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }
        buffer[Position] = bytes[0];
        buffer[Position + 1] = bytes[1];
        buffer[Position + 2] = bytes[2];
        buffer[Position + 3] = bytes[3];

        Position += FloatLen;
    }
    /// <summary>
    /// Writes a double
    /// </summary>
    public void Write(double value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (Position + DoubleLen > Buffer.Length)
        {
            Position += DoubleLen;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }

        var buffer = Buffer.AsSpan();
        
        Span<byte> bytes = stackalloc byte[DoubleLen];
        if (!BitConverter.TryWriteBytes(bytes, value))
        {
            Position += DoubleLen;
            var ex = new Exception($"Writer failed to write double {value} to span! {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }
        
        buffer[Position] = bytes[0];
        buffer[Position + 1] = bytes[1];
        buffer[Position + 2] = bytes[2];
        buffer[Position + 3] = bytes[3];
        buffer[Position + 4] = bytes[4];
        buffer[Position + 5] = bytes[5];
        buffer[Position + 6] = bytes[6];
        buffer[Position + 7] = bytes[7];

        Position += DoubleLen;
    }
    /// <summary>
    /// Writes a string using short for length of the string
    /// </summary>
    public void Write(string value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (value.Length == 0) {
            Write((ushort)0);
            return;
        }

        var bytes = Encoding.UTF8.GetBytes(value);
        Write((ushort)bytes.Length);
        if (Position + bytes.Length > Buffer.Length)
        {
            Position += bytes.Length;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }

        var buffer = Buffer.AsSpan();
        bytes.CopyTo(buffer[Position..(Position + bytes.Length)]);
        Position += bytes.Length;
    }
    /// <summary>
    /// Writes a string using int for the length of the string
    /// </summary>
    public void WriteUtf16(string value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
    {
        if (value.Length == 0) {
            Write(0);
            return;
        }

        var bytes = Encoding.UTF8.GetBytes(value);
        Write(bytes.Length);
        if (Position + bytes.Length > Buffer.Length)
        {
            Position += bytes.Length;
            var ex = new ArgumentOutOfRangeException($"Writer attempted to write out of bounds: {Position}, {Buffer.Length} via {caller} \n\t at {path} L.{line}");
            throw ex;
        }

        var buffer = Buffer.AsSpan();
        var b = Buffer.AsSpan();
        bytes.CopyTo(b[Position..(Position + bytes.Length)]);
        Position += bytes.Length;
    }
}