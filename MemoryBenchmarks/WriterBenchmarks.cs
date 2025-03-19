using BenchmarkDotNet.Attributes;
using OryxEngine.Memory;

namespace MemoryBenchmarks;

[MemoryDiagnoser]
public class WriterBenchmarks
{
    private static byte[] _data = new byte[0x10000];
    private static Writer _writer;
    
    [Params(0, 1)]
    public EndianMode Mode; 

    [GlobalSetup]
    public void Setup() {
        _writer = new Writer(Mode, _data);
    }

    [Benchmark]
    public void WriteByte() {
        _writer.Reset();
        _writer.Write(byte.MaxValue);
        _writer.Write(byte.MinValue);
        _writer.Write((byte)10);
    }
    
    [Benchmark]
    public void WriteBoolean() {
        _writer.Reset();
        _writer.Write(true);
        _writer.Write(false);
    }
    
    [Benchmark]
    public void WriteShort() {
        _writer.Reset();
        _writer.Write(short.MaxValue);
        _writer.Write(short.MinValue);
        _writer.Write((short)1453);
        _writer.Write((short)10);
        _writer.Write((short)-12452);
    }
    
    [Benchmark]
    public void WriteUShort() {
        _writer.Reset();
        _writer.Write(ushort.MaxValue);
        _writer.Write(ushort.MinValue);
        _writer.Write((ushort)1453);
        _writer.Write((ushort)10);
        _writer.Write((ushort)45345);
    }
    
    [Benchmark]
    public void WriteInt() {
        _writer.Reset();
        _writer.Write(int.MaxValue);
        _writer.Write(int.MinValue);
        _writer.Write(1453);
        _writer.Write(10);
        _writer.Write(-12452);
    }
    
    [Benchmark]
    public void WriteUInt() {
        _writer.Reset();
        _writer.Write(uint.MaxValue);
        _writer.Write(uint.MinValue);
        _writer.Write((uint)1453);
        _writer.Write((uint)10);
        _writer.Write((uint)45345);
    }
    
    [Benchmark]
    public void WriteLong() {
        _writer.Reset();
        _writer.Write(long.MaxValue);
        _writer.Write(long.MinValue);
        _writer.Write((long)36455235423);
        _writer.Write((long)123313234);
        _writer.Write((long)-324234243);
    }
    
    [Benchmark]
    public void WriteULong() {
        _writer.Reset();
        _writer.Write(ulong.MaxValue);
        _writer.Write(ulong.MinValue);
        _writer.Write((ulong)36455235423);
        _writer.Write((ulong)123313234);
        _writer.Write((ulong)324234243543);
    }
    
    [Benchmark]
    public void WriteFloat() {
        _writer.Reset();
        _writer.Write(float.MaxValue);
        _writer.Write(float.MinValue);
        _writer.Write(10.1f);
        _writer.Write(1000f);
        _writer.Write(-10.1f);
    }

    [Benchmark] 
    public void WriteDouble() {
        _writer.Reset();
        _writer.Write(double.MaxValue);
        _writer.Write(double.MinValue);
        _writer.Write(10.1);
        _writer.Write(1000.0);
        _writer.Write(-10.1);
    }
    
    [Benchmark]
    public void WriteString() {
        _writer.Reset();
        _writer.WriteString("This is a very easy test"); //26
        _writer.WriteString("This is a very easy test, This is a very easy test, This is a very easy test, This is a very easy test, This is a very easy test"); //130?
    }

    [Benchmark] 
    public void WriteStringInt() {
        _writer.Reset();
        _writer.WriteStringInt("This is a very easy test");
        _writer.WriteStringInt("This is a very easy test, This is a very easy test, This is a very easy test, This is a very easy test, This is a very easy test");
    }
}