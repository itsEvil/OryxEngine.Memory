using System.Runtime.CompilerServices;

namespace MemoryTools;
public class Writer(EndianMode mode, byte[] buffer) : IWriter
{
    private readonly IWriter _writer = mode == EndianMode.Big ?
            new WriterBig(buffer) :
            new WriterLittle(buffer);
    public readonly EndianMode Mode = mode;
    public byte[] Buffer => _writer.Buffer;
    public int Position => _writer.Position;
    public void Reset() => _writer.Reset();
    public void SetPosition(int position) => _writer.SetPosition(position);
    public void Write(byte value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) 
        => _writer.Write(value, caller, path, line);
    public void Write(bool value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.Write(value, caller, path, line);
    public void Write(char value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.Write(value, caller, path, line);
    public void Write(ushort value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.Write(value, caller, path, line);
    public void Write(short value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.Write(value, caller, path, line);
    public void Write(uint value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.Write(value, caller, path, line);
    public void Write(int value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.Write(value, caller, path, line);
    public void Write(float value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.Write(value, caller, path, line);
    public void Write(double value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.Write(value, caller, path, line);
    public void Write(ulong value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.Write(value, caller, path, line);
    public void Write(long value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.Write(value, caller, path, line);
    public void Write(string value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.Write(value, caller, path, line);
    public void WriteUtf16(string value, [CallerMemberName] string caller = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => _writer.WriteUtf16(value, caller, path, line);
}