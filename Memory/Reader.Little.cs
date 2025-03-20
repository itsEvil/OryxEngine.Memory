using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Text;
// ReSharper disable once CheckNamespace
namespace OryxEngine.Memory;
public sealed class ReaderLittle : IReader
{
    private const int ByteLen = sizeof(byte);
    private const int BoolLen = sizeof(bool);
    private const int ShortLen = sizeof(short);
    private const int IntLen = sizeof(int);
    private const int LongLen = sizeof(long);
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

        var data = BinaryPrimitives.ReadInt16LittleEndian(GetSpan(ShortLen));
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

        var data = BinaryPrimitives.ReadUInt16LittleEndian(GetSpan(ShortLen));
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

        var data = BinaryPrimitives.ReadInt32LittleEndian(GetSpan(IntLen));
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

        var data = BinaryPrimitives.ReadUInt32LittleEndian(GetSpan(IntLen));
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

        var data = BinaryPrimitives.ReadInt64LittleEndian(GetSpan(LongLen));
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
        
        var data = BinaryPrimitives.ReadUInt64LittleEndian(GetSpan(LongLen));
        Position += LongLen;
        return data;
    }
    public float ReadFloat() => BitConverter.UInt32BitsToSingle(ReadUInt32());
    public double ReadDouble() => BitConverter.UInt64BitsToDouble(ReadUInt64());
    /// <summary>
    /// Reads a string using ushort for length of the string
    /// </summary>
    public string ReadString() 
    {
        var length = ReadUInt16();
        if (length + Position > Length)
            throw new ArgumentOutOfRangeException($"Length + Position is out of buffer bounds, {length} + {Position} > {Buffer.Length}");
        
        if (length == 0)
            return "";

        var r = Encoding.UTF8.GetString(Buffer, Position, length);
        Position += length;
        return r;
    }
    /// <summary>
    /// Reads a string using ushort for length of the string
    /// </summary>
    public string ReadStringInt() 
    {
        var length = ReadInt32();
        if (length + Position > Length)
            throw new ArgumentOutOfRangeException($"Length + Position is out of buffer bounds, {length} + {Position} > {Buffer.Length}");
        
        if (length == 0)
            return "";
        
        var r = Encoding.UTF8.GetString(Buffer, Position, length);
        Position += length;
        return r;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Span<byte> GetSpan(int length) => Buffer.AsSpan(Position, length);
}