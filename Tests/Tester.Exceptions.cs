using OryxEngine.Memory;
using static Tests.Asserts;

// ReSharper disable once CheckNamespace
namespace Tests;

public class TesterExceptions {
    
    private readonly byte[] _bigData = new byte[0x10000];
    private readonly byte[] _littleData = new byte[0x10000];
    public TesterExceptions() {
        //Initialize our objects
        var bigReader = new Reader(EndianMode.Big, _bigData);
        var littleReader = new Reader(EndianMode.Little, _littleData);
        
        var bigWriter = new Writer(EndianMode.Big, _bigData);
        var littleWriter = new Writer(EndianMode.Little, _littleData);

        //Set to the length of the data we received, in this case it's the entire buffer
        bigReader.Reset(_bigData.Length);
        littleReader.Reset(_littleData.Length);

        try
        {
            Run(bigReader, bigWriter);
            Run(littleReader, littleWriter);
        }
        catch (Exception e)
        {
            Console.WriteLine("Caught Error: {0} {1}", e.Message, e.StackTrace ?? "Stack Trace is null");
        }
    }

    private static void Run(Reader r, Writer w) {
        Write(w);
        Read(r);
    }
    private static void Write(Writer w)
    {
        ResetPositions(WriterIndex);
        w.Write(byte.MinValue);
        w.Write(byte.MaxValue);
        w.Write((byte)128);
        
        PrintPosition(w);
        
        w.Write(false);
        w.Write(true);
        PrintPosition(w);
        
        w.WriteString("This is a string using ushort as length");
        PrintPosition(w);
        
        w.WriteStringInt("This is a string using int as length");
        PrintPosition(w);
        
        w.Write(short.MinValue);
        w.Write(short.MaxValue);
        w.Write((short)10);
        
        PrintPosition(w);
        
        w.Write(ushort.MinValue);
        w.Write(ushort.MaxValue);
        w.Write((ushort)10);
        
        PrintPosition(w);
        
        w.Write(int.MinValue);
        w.Write(int.MaxValue);
        w.Write(10);
        
        PrintPosition(w);
        
        w.Write(uint.MinValue);
        w.Write(uint.MaxValue);
        w.Write((uint)10);
        
        PrintPosition(w);
        
        w.Write(long.MinValue);
        w.Write(long.MaxValue);
        w.Write((long)10);
        
        PrintPosition(w);
        
        w.Write(ulong.MinValue);
        w.Write(ulong.MaxValue);
        w.Write((ulong)10);
        
        PrintPosition(w);
        
        w.Write(float.MinValue);
        w.Write(float.MaxValue);
        w.Write(10.1f);
        
        PrintPosition(w);
        
        w.Write(double.MinValue);
        w.Write(double.MaxValue);
        w.Write(10.1);
        
        PrintPosition(w);
    }
    private static void Read(Reader r)
    {
        ResetPositions(ReaderIndex);
        var byte0 = r.ReadByte();
        var byte1 = r.ReadByte();
        var byte2 = r.ReadByte();

        PrintPosition(r);
        
        var bool0 = r.ReadBoolean();
        var bool1 = r.ReadBoolean();
        
        PrintPosition(r);
        
        var ushortString = r.ReadString();
        PrintPosition(r);
        var intString = r.ReadStringInt();
        PrintPosition(r);
        
        var short0 = r.ReadInt16();
        var short1 = r.ReadInt16();
        var short2 = r.ReadInt16();
        
        PrintPosition(r);
        
        var ushort0 = r.ReadUInt16();
        var ushort1 = r.ReadUInt16();
        var ushort2 = r.ReadUInt16();
        
        PrintPosition(r);

        var int0 = r.ReadInt32();
        var int1 = r.ReadInt32();
        var int2 = r.ReadInt32();
        
        PrintPosition(r);
        
        var uint0 = r.ReadUInt32();
        var uint1 = r.ReadUInt32();
        var uint2 = r.ReadUInt32();
        
        PrintPosition(r);

        var long0 = r.ReadInt64();
        var long1 = r.ReadInt64();
        var long2 = r.ReadInt64();
        
        PrintPosition(r);
        
        var ulong0 = r.ReadUInt64();
        var ulong1 = r.ReadUInt64();
        var ulong2 = r.ReadUInt64();
        
        PrintPosition(r);
        
        var float0 = r.ReadFloat();
        var float1 = r.ReadFloat();
        var float2 = r.ReadFloat();
        
        PrintPosition(r);
        
        var double0 = r.ReadDouble();
        var double1 = r.ReadDouble();
        var double2 = r.ReadDouble();
        
        PrintPosition(r);

        Prefix = $"{r.Mode} | ";
        
        Assert(byte0, byte.MinValue);
        Assert(byte1, byte.MaxValue);
        Assert(byte2, (byte)128);
        
        Assert(bool0, false);
        Assert(bool1, true);
        
        PrintPosition(r);
        Assert(ushortString, "This is a string using ushort as length");
        PrintPosition(r);
        Assert(intString, "This is a string using int as length");
        PrintPosition(r);

        Assert(short0, short.MinValue);
        Assert(short1, short.MaxValue);
        Assert(short2, (short)10);
        
        Assert(ushort0, ushort.MinValue);
        Assert(ushort1, ushort.MaxValue);
        Assert(ushort2, (ushort)10);
        
        Assert(int0, int.MinValue);
        Assert(int1, int.MaxValue);
        Assert(int2, 10);
        
        Assert(uint0, uint.MinValue);
        Assert(uint1, uint.MaxValue);
        Assert(uint2, 10);
        
        Assert(long0, long.MinValue);
        Assert(long1, long.MaxValue);
        Assert(long2, (long)10);
        
        Assert(ulong0, ulong.MinValue);
        Assert(ulong1, ulong.MaxValue);
        Assert(ulong2, (ulong)10);
        
        Assert(float0, float.MinValue);
        Assert(float1, float.MaxValue);
        Assert(float2, 10.1f);
        
        Assert(double0, double.MinValue);
        Assert(double1, double.MaxValue);
        Assert(double2, 10.1);

        PrintCounts();
    }
}