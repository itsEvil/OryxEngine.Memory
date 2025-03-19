// ReSharper disable once CheckNamespace
namespace OryxEngine.Memory;
internal interface IReader
{
    public byte[] Buffer { get; }
    public int Position { get; set; }
    public int Length { get; }
    public void Reset(int length);
    public byte PeekByte();
    public byte ReadByte();
    public bool ReadBoolean();
    public short ReadInt16();
    public ushort ReadUInt16();
    public int ReadInt32();
    public uint ReadUInt32();
    public long ReadInt64();
    public ulong ReadUInt64();
    public float ReadFloat();
    public double ReadDouble();
    public string ReadString();
    public string ReadStringInt();
}
