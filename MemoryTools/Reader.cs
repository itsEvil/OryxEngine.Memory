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
    public char PeekChar([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.PeekChar(caller, path, line);
    public byte PeekByte([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.PeekByte(caller, path, line);
    public byte ReadByte([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadByte(caller, path, line);
    public char ReadChar([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadChar(caller, path, line);
    public bool ReadBoolean([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadBoolean(caller, path, line);
    public short ReadInt16([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadInt16(caller, path, line);
    public ushort ReadUInt16([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadUInt16(caller, path, line);
    public int ReadInt32([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadInt32(caller, path, line);
    public uint ReadUInt32([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadUInt32(caller, path, line);
    public long ReadInt64([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadInt64(caller, path, line);
    public ulong ReadUInt64([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadUInt64(caller, path, line);
    public float ReadFloat([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadFloat(caller, path, line);
    public double ReadDouble([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadDouble(caller, path, line);
    public string ReadUtf8Short([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadUtf8Short(caller, path, line);
    public string ReadUtf8Int([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _reader.ReadUtf8Int(caller, path, line);
}
