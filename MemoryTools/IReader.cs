using System.Runtime.CompilerServices;

namespace MemoryTools;
internal interface IReader
{
    public byte[] Buffer { get; }
    public int Position { get; }
    public int Length { get; }
    public void Reset(int length);
#if DEBUG
    public char PeekChar([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public byte PeekByte([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public byte ReadByte([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public char ReadChar([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public bool ReadBoolean([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public short ReadInt16([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public ushort ReadUInt16([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public int ReadInt32([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public uint ReadUInt32([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public long ReadInt64([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public ulong ReadUInt64([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public float ReadFloat([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public double ReadDouble([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public string ReadUtf8Short([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
    public string ReadUtf8Int([CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0);
#elif RELEASE
    public char PeekChar();
    public byte PeekByte();
    public byte ReadByte();
    public char ReadChar();
    public bool ReadBoolean();
    public short ReadInt16();
    public ushort ReadUInt16();
    public int ReadInt32();
    public uint ReadUInt32();
    public long ReadInt64();
    public ulong ReadUInt64();
    public float ReadFloat();
    public double ReadDouble();
    public string ReadUtf8Short();
    public string ReadUtf8Int();
#endif
}
