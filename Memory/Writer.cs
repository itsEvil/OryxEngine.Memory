// ReSharper disable once CheckNamespace
namespace OryxEngine.Memory;
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
    public void Write(byte value) => _writer.Write(value);
    public void Write(bool value) => _writer.Write(value);
    public void Write(ushort value) => _writer.Write(value);
    public void Write(short value) => _writer.Write(value);
    public void Write(uint value) => _writer.Write(value);
    public void Write(int value) => _writer.Write(value);
    public void Write(float value) => _writer.Write(value);
    public void Write(double value) => _writer.Write(value);
    public void Write(ulong value) => _writer.Write(value);
    public void Write(long value) => _writer.Write(value);
    public void WriteString(ReadOnlySpan<char> value) => _writer.WriteString(value);
    public void WriteStringInt(ReadOnlySpan<char> value) => _writer.WriteStringInt(value);
}