using OryxEngine.Optionals;

// ReSharper disable once CheckNamespace
namespace OryxEngine.Memory.Optionals;

internal interface IReader
{
    public byte[] Buffer { get; }
    public int Position { get; set; }
    public int Length { get; }
    public void Reset(int length);
    public void Clear();
    public Option<byte> PeekByte();
    public Option<byte> ReadByte();
    public Option<bool> ReadBoolean();
    public Option<short> ReadInt16();
    public Option<ushort> ReadUInt16();
    public Option<int> ReadInt32();
    public Option<uint> ReadUInt32();
    public Option<long> ReadInt64();
    public Option<ulong> ReadUInt64();
    public Option<float> ReadFloat();
    public Option<double> ReadDouble();
    public Option<string> ReadString();
    public Option<string> ReadStringInt();
}
