using BenchmarkDotNet.Attributes;
using OryxEngine.Memory;

namespace MemoryBenchmarks;

[MemoryDiagnoser]
public class ReaderBenchmarksStrings
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