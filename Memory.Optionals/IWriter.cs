// ReSharper disable once CheckNamespace

using OryxEngine.Optionals;

namespace OryxEngine.Memory.Optionals;
public interface IWriter
{
    public byte[] Buffer { get; }
    public int Position { get; }
    public void Reset();
    public void SetPosition(int position);
    public Option<bool> Write(byte value);
    public Option<bool> Write(bool value);
    public Option<bool> Write(ushort value);
    public Option<bool> Write(short value);
    public Option<bool> Write(uint value);
    public Option<bool> Write(int value);
    public Option<bool> Write(float value);
    public Option<bool> Write(double value);
    public Option<bool> Write(ulong value);
    public Option<bool> Write(long value);
    public Option<bool> WriteString(ReadOnlySpan<char> value);
    public Option<bool> WriteStringInt(ReadOnlySpan<char> value);
}
