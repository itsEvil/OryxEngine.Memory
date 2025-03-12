using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTools;
public enum EndianMode
{
    Little,
    Big,
}
/// <summary>
/// Wrapper class for a binary reader
/// </summary>
public class Reader(EndianMode mode, byte[] buffer) : IReader {
    
    private readonly IReader _reader = mode == EndianMode.Little ?
            new ReaderLittle(buffer) : new ReaderBig(buffer);
    public readonly EndianMode Mode = mode;
    public byte[] Buffer => _reader.Buffer;
    public int Position => _reader.Position;
    public int Length => _reader.Length;
    public void Reset(int length) => _reader.Reset(length);
    public char PeekChar() => _reader.PeekChar();
    public byte PeekByte() => _reader.PeekByte();
    public byte ReadByte() => _reader.ReadByte();
    public char ReadChar() => _reader.ReadChar();
    public bool ReadBoolean() => _reader.ReadBoolean();
    public short ReadInt16() => _reader.ReadInt16();
    public ushort ReadUInt16() => _reader.ReadUInt16();
    public int ReadInt32() => _reader.ReadInt32();
    public uint ReadUInt32() => _reader.ReadUInt32();
    public long ReadInt64() => _reader.ReadInt64();
    public ulong ReadUInt64() => _reader.ReadUInt64();
    public float ReadFloat() => _reader.ReadFloat();
    public double ReadDouble() => _reader.ReadDouble();
    public string ReadUtf8Short() => _reader.ReadUtf8Short();
    public string ReadUtf8Int() => _reader.ReadUtf8Int();
}
