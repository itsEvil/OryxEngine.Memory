using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryTools;
#if RELEASE
public sealed class ReaderLittle : IReader
{
    private const int ByteLen = sizeof(byte);
    private const int BoolLen = sizeof(bool);
    private const int CharLen = sizeof(char);
    private const int ShortLen = sizeof(short);
    private const int IntLen = sizeof(int);
    private const int LongLen = sizeof(long);
    private const int FloatLen = sizeof(float);
    private const int DoubleLen = sizeof(double);

    public int Position { get; private set; }

    public int Length { get; private set; }

    private readonly byte[] _buffer;
    public byte[] Buffer => _buffer ?? [];
    public ReaderLittle(byte[] buffer)
    {
        _buffer = buffer;
        Length = _buffer.Length;
    }
    public void Reset(int length)
    {
        Length = length;
        Position = 0;
    }
    public char PeekChar()
    {
        if (Position + CharLen <= Length) 
            return (char)_buffer[Position];
        
        var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
        throw ex;

    }
    public byte PeekByte()
    {
        if (Position + ByteLen <= Length) 
            return _buffer[Position];
        
        var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
        throw ex;

    }
    public byte ReadByte()
    {
        if (Position + ByteLen <= Length) 
            return _buffer[Position++];
        
        Position++;
        var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
        throw ex;

    }
    public char ReadChar()
    {
        if (Position + CharLen <= Length) {
            var ret = (char)(_buffer[Position] + _buffer[Position + 1]); //Read it normally cos its little Endian
            Position += CharLen;
            return ret;
        }
        
        var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
        throw ex;
    }

    public bool ReadBoolean()
    {
        if (Position + BoolLen <= Length) 
            return _buffer[Position++] == 1;
        
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

        var data = BinaryPrimitives.ReadInt16LittleEndian(_buffer.AsSpan()[Position..(Position + ShortLen)]);
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

        var data = BinaryPrimitives.ReadUInt16LittleEndian(_buffer.AsSpan()[Position..(Position + ShortLen)]);
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

        var data = BinaryPrimitives.ReadInt32LittleEndian(_buffer.AsSpan()[Position..(Position + IntLen)]);
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

        var data = BinaryPrimitives.ReadUInt32LittleEndian(_buffer.AsSpan()[Position..(Position + IntLen)]);
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

        var data = BinaryPrimitives.ReadInt64LittleEndian(_buffer.AsSpan()[Position..(Position + LongLen)]);
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

        var data = BinaryPrimitives.ReadUInt64LittleEndian(_buffer.AsSpan()[Position..(Position + LongLen)]);
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
        
        var data = BitConverter.ToSingle(_buffer.AsSpan()[Position..(Position + FloatLen)]);
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
        
        var data = BitConverter.ToDouble(_buffer.AsSpan()[Position..(Position + DoubleLen)]);
        Position += DoubleLen;
        return data;
    }
    /// <summary>
    /// Reads a <see cref="short"/> length then tries to read <see cref="string"/> using the length.
    /// </summary>
    public string ReadUtf8Short()
    {
        var length = ReadInt16();
        switch (length)
        {
            case 0:
                return "";
            case < 0:
            {
                var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
                throw ex;
            }
        }


        if (Position + length > Length)
        {
            Position += length;
            var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
            throw ex;
        }

        var data = Encoding.UTF8.GetString(_buffer[Position..(Position + length)]);
        Position += length;
        return data;
    }
    /// <summary>
    /// Reads a <see cref="int"/> length then tries to read <see cref="string"/> using the length.
    /// </summary>
    public string ReadUtf8Int()
    {
        var length = ReadInt32();
        switch (length)
        {
            case 0:
                return "";
            case < 0:
            {
                var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
                throw ex;
            }
        }


        if (Position + length > Length)
        {
            Position += length;
            var ex = new Exception($"Receive buffer attempted to read out of bounds {Position}, {Length}");
            throw ex;
        }

        var data = Encoding.UTF8.GetString(_buffer[Position..(Position + length)]);
        Position += length;

        return data;
    }
}
#endif