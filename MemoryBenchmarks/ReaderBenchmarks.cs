using BenchmarkDotNet.Attributes;
using OryxEngine.Memory;

namespace MemoryBenchmarks;

[MemoryDiagnoser]
public class ReaderBenchmarks
{
    private static byte[] _data = new byte[0x10000];
    private static Reader _reader;
    
    [Params(0, 1)]
    public EndianMode Mode; 

    [GlobalSetup]
    public void Setup()
    {
        _data.AsSpan().Clear();
        var w = new Writer(Mode, _data);
        w.Write(byte.MaxValue);
        w.Write(byte.MinValue);
        w.Write((byte)10);
        w.Write(true);
        w.Write(false);
        w.Write(short.MaxValue);
        w.Write(short.MinValue);
        w.Write((short)1453);
        w.Write((short)10);
        w.Write((short)-12452);
        w.Write(ushort.MaxValue);
        w.Write(ushort.MinValue);
        w.Write((ushort)1453);
        w.Write((ushort)10);
        w.Write((ushort)45345);
        w.Write(int.MaxValue);
        w.Write(int.MinValue);
        w.Write(1453);
        w.Write(10);
        w.Write(-12452);
        w.Write(uint.MaxValue);
        w.Write(uint.MinValue);
        w.Write((uint)1453);
        w.Write((uint)10);
        w.Write((uint)45345);
        w.Write(long.MaxValue);
        w.Write(long.MinValue);
        w.Write((long)36455235423);
        w.Write((long)123313234);
        w.Write((long)-324234243);
        w.Write(ulong.MaxValue);
        w.Write(ulong.MinValue);
        w.Write((ulong)36455235423);
        w.Write((ulong)123313234);
        w.Write((ulong)324234243543);
        w.Write(float.MaxValue);
        w.Write(float.MinValue);
        w.Write(10.1f);
        w.Write(1000f);
        w.Write(-10.1f);
        w.Write(double.MaxValue);
        w.Write(double.MinValue);
        w.Write(10.1);
        w.Write(1000.0);
        w.Write(-10.1);
        w.WriteString("This is a very easy test");
        w.WriteString("This is a very easy test, This is a very easy test, This is a very easy test, This is a very easy test, This is a very easy test");
        
        w.WriteStringInt("This is a very easy test");
        w.WriteStringInt("This is a very easy test, This is a very easy test, This is a very easy test, This is a very easy test, This is a very easy test");
        _reader = new Reader(Mode, _data);
    }

    [Benchmark]
    public void ReadByte() {
        _reader.Reset(_data.Length);
        var byte0 = _reader.ReadByte();
        var byte1 = _reader.ReadByte();
        var byte2 = _reader.ReadByte();
    }
    
    [Benchmark]
    public void ReadBoolean()
    {
        _reader.Reset(_data.Length);
        _reader.Position = 3;
        var boolean0 = _reader.ReadBoolean();
        var boolean1 = _reader.ReadBoolean();
    }
    
    [Benchmark]
    public void ReadShort() {
        _reader.Reset(_data.Length);
        _reader.Position = 5;
        var short0 = _reader.ReadInt16();
        var short1 = _reader.ReadInt16();
        var short2 = _reader.ReadInt16();
        var short3 = _reader.ReadInt16();
        var short4 = _reader.ReadInt16();
    }
    
    [Benchmark]
    public void ReadUShort() {
        _reader.Reset(_data.Length);
        _reader.Position = 15;
        var ushort0 = _reader.ReadUInt16();
        var ushort1 = _reader.ReadUInt16();
        var ushort2 = _reader.ReadUInt16();
        var ushort3 = _reader.ReadUInt16();
        var ushort4 = _reader.ReadUInt16();
    }
    
    [Benchmark]
    public void ReadInt() {
        _reader.Reset(_data.Length);
        _reader.Position = 25;
        var int0 = _reader.ReadInt32();
        var int1 = _reader.ReadInt32();
        var int2 = _reader.ReadInt32();
        var int3 = _reader.ReadInt32();
        var int4 = _reader.ReadInt32();
    }
    
    [Benchmark]
    public void ReadUInt() {
        _reader.Reset(_data.Length);
        _reader.Position = 45;
        var uint0 = _reader.ReadUInt32();
        var uint1 = _reader.ReadUInt32();
        var uint2 = _reader.ReadUInt32();
        var uint3 = _reader.ReadUInt32();
        var uint4 = _reader.ReadUInt32();
    }
    
    [Benchmark]
    public void ReadLong() {
        _reader.Reset(_data.Length);
        _reader.Position = 65;
        var long0 = _reader.ReadInt64();
        var long1 = _reader.ReadInt64();
        var long2 = _reader.ReadInt64();
        var long3 = _reader.ReadInt64();
        var long4 = _reader.ReadInt64();
    }
    
    [Benchmark]
    public void ReadULong() {
        _reader.Reset(_data.Length);
        _reader.Position = 105;
        var ulong0 = _reader.ReadUInt64();
        var ulong1 = _reader.ReadUInt64();
        var ulong2 = _reader.ReadUInt64();
        var ulong3 = _reader.ReadUInt64();
        var ulong4 = _reader.ReadUInt64();
    }
    
    [Benchmark]
    public void ReadFloat() {
        _reader.Reset(_data.Length);
        _reader.Position = 145;
        var float0 = _reader.ReadFloat();
        var float1 = _reader.ReadFloat();
        var float2 = _reader.ReadFloat();
        var float3 = _reader.ReadFloat();
        var float4 = _reader.ReadFloat();
    }

    [Benchmark] 
    public void ReadDouble() {
        _reader.Reset(_data.Length);
        _reader.Position = 165;
        var double0 = _reader.ReadDouble();
        var double1 = _reader.ReadDouble();
        var double2 = _reader.ReadDouble();
        var double3 = _reader.ReadDouble();
        var double4 = _reader.ReadDouble();
    }
    
    [Benchmark]
    public void ReadString() {
        _reader.Reset(_data.Length);
        _reader.Position = 205;
        var string0 = _reader.ReadString();
        var string1 = _reader.ReadString();
    }
    
    [Benchmark]
    public void ReadStringInt() {
        _reader.Reset(_data.Length);
        _reader.Position = 361;
        var string0 = _reader.ReadStringInt();
        var string1 = _reader.ReadStringInt();
    }
}