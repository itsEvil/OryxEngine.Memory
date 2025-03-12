using System.Runtime.CompilerServices;

namespace MemoryTools;
public interface IWriter
{
    public byte[] Buffer { get; }
    public int Position { get; }
    public void Reset();
    public void SetPosition(int position);
    public void Write(byte value);
    public void Write(bool value);
    public void Write(char value);
    public void Write(ushort value);
    public void Write(short value);
    public void Write(uint value);
    public void Write(int value);
    public void Write(float value);
    public void Write(double value);
    public void Write(ulong value);
    public void Write(long value);
    public void Write(string value);
    public void WriteUtf16(string value);
}
