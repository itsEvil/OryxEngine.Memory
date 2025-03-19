using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryTools;
public sealed class ReaderLittle : IReader
{
    private const int ByteLen = sizeof(byte);
    private const int BoolLen = sizeof(bool);
    private const int ShortLen = sizeof(short);
    private const int IntLen = sizeof(int);
    private const int LongLen = sizeof(long);
    private const int FloatLen = sizeof(float);
    private const int DoubleLen = sizeof(double);

    public int Position { get; set; }

    public int Length { get; private set; }

    public byte[] Buffer { get; }

    public ReaderLittle(byte[] buffer)
    {
        Buffer = buffer;
        Length = Buffer.Length;
    }
    public void Reset(int length)
    {
        Length = length;
        Position = 0;
    }
    public byte PeekByte()
    {
        if (Position + ByteLen <= Length) 
            return Buffer[Position];
        
        var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
        throw ex;

    }
    public byte ReadByte()
    {
        if (Position + ByteLen <= Length) 
            return Buffer[Position++];
        
        Position++;
        var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
        throw ex;
    }
    
    public bool ReadBoolean()
    {
        if (Position + BoolLen <= Length) 
            return Buffer[Position++] == 1;
        
        Position++;
        var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
        throw ex;
    }

    public short ReadInt16()
    {
        if (Position + ShortLen > Length)
        {
            Position += ShortLen;
            var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
            throw ex;
        }

        var data = BinaryPrimitives.ReadInt16LittleEndian(Buffer.AsSpan()[Position..(Position + ShortLen)]);
        Position += ShortLen;
        return data;
    }
    public ushort ReadUInt16()
    {
        if (Position + ShortLen > Length)
        {
            Position += ShortLen;
            var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
            throw ex;
        }

        var span = Buffer.AsSpan(Position, ShortLen);
        var data = BinaryPrimitives.ReadUInt16LittleEndian(span);
        Position += ShortLen;
        return data;
    }
    public int ReadInt32()
    {
        if (Position + IntLen > Length)
        {
            Position += IntLen;
            var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
            throw ex;
        }

        var span = Buffer.AsSpan(Position,IntLen);
        var data = BinaryPrimitives.ReadInt32LittleEndian(span);
        Position += IntLen;
        return data;
    }
    public uint ReadUInt32()
    {
        if (Position + IntLen > Length)
        {
            Position += IntLen;
            var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
            throw ex;
        }

        var span = Buffer.AsSpan(Position, IntLen);
        var data = BinaryPrimitives.ReadUInt32LittleEndian(span);
        Position += IntLen;
        return data;
    }

    public long ReadInt64()
    {
        if (Position + LongLen > Length)
        {
            Position += LongLen;
            var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
            throw ex;
        }

        var span = Buffer.AsSpan(Position, LongLen);
        var data = BinaryPrimitives.ReadInt64LittleEndian(span);
        Position += LongLen;
        return data;
    }

    public ulong ReadUInt64()
    {
        if (Position + LongLen > Length)
        {
            Position += LongLen;
            var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
            throw ex;
        }
        
        var span = Buffer.AsSpan(Position, LongLen);
        var data = BinaryPrimitives.ReadUInt64LittleEndian(span);
        Position += LongLen;
        return data;
    }

    public float ReadFloat()
    {
        if (Position + FloatLen > Length)
        {
            Position += FloatLen;
            var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
            throw ex;
        }
        
        var span = Buffer.AsSpan(Position, FloatLen);
        var data = BitConverter.ToSingle(span);
        Position += FloatLen;
        return data;
    }
    public double ReadDouble()
    {
        if (Position + DoubleLen > Length)
        {
            Position += DoubleLen;
            var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
            throw ex;
        }
        
        var span = Buffer.AsSpan(Position, DoubleLen);
        var data = BitConverter.ToDouble(span);
        Position += DoubleLen;
        return data;
    }
    /// <summary>
    /// Reads a string using ushort for length of the string
    /// </summary>
    public string ReadString() {
        var length = ReadUInt16();
        if (length + Position > Length)
            throw new ArgumentOutOfRangeException($"Length + Position is out of buffer bounds, {length} + {Position} > {Buffer.Length}");
        
        if (length == 0)
            return "";

        var r = Encoding.UTF8.GetString(Buffer, Position, length);
        Position += length;
        return r;
        
        const int maxStackLimit = 512;
        var chars = length <= maxStackLimit ? stackalloc char[length] : new char[length];
        
        var buffer = new ReadOnlySpan<byte>(Buffer, Position, length);
        Position += length;
        
        if (Encoding.UTF8.TryGetChars(buffer, chars, out var written)) 
            return string.Intern(chars.ToString());
        
        throw new ArgumentOutOfRangeException($"Reader failed to get chars at: {Position}, written chars: {written}, length: {length}");
    }
    /// <summary>
    /// Reads a string using ushort for length of the string
    /// </summary>
    public string ReadStringInt() {
        var length = ReadInt32();
        if (length + Position > Length)
            throw new ArgumentOutOfRangeException($"Length + Position is out of buffer bounds, {length} + {Position} > {Buffer.Length}");
        
        if (length == 0)
            return "";
        
        var r = Encoding.UTF8.GetString(Buffer, Position, length);
        Position += length;
        return r;
        
        const int maxStackLimit = 512;
        var chars = length <= maxStackLimit ? stackalloc char[length] : new char[length];
        
        var buffer = new ReadOnlySpan<byte>(Buffer, Position, length);
        Position += length;
        
        if (Encoding.UTF8.TryGetChars(buffer, chars, out var written)) 
            return string.Intern(chars.ToString());
        
        throw new ArgumentOutOfRangeException($"Reader failed to get chars at: {Position}, written chars: {written}, length: {length}");
    }
}