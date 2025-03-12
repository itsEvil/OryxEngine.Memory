using System.Diagnostics;
using System.Runtime.CompilerServices;
using MemoryTools;

namespace MemoryTests;

public class Tester {
    
    private readonly byte[] _bigData = new byte[0x10000];
    private readonly byte[] _littleData = new byte[0x10000];

    public Tester() {
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
        Console.WriteLine("Reader Mode: {0}, Writer Mode: {1}", r.Mode, w.Mode);

        Write(w);
        Read(r);
    }
    private static void Write(Writer w)
    {
        w.Write(byte.MinValue);
        w.Write(byte.MaxValue);
        w.Write((byte)128);
        
        PrintPosition(w);
        
        w.Write(false);
        w.Write(true);
        
        PrintPosition(w);
        
        w.Write(char.MinValue);
        w.Write(char.MaxValue);
        w.Write((char)128);
        
        PrintPosition(w);
        
        w.Write("This is a string");
        
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
        
        Console.WriteLine("Wrote {0} bytes to {1} buffer", w.Position, w.Mode);
    }
    private static void Read(Reader r)
    {
        var byte0 = r.ReadByte();
        var byte1 = r.ReadByte();
        var byte2 = r.ReadByte();

        PrintPosition(r);
        
        var bool0 = r.ReadBoolean();
        var bool1 = r.ReadBoolean();
        
        PrintPosition(r);
        
        var char0 = r.ReadChar();
        var char1 = r.ReadChar();
        var char2 = r.ReadChar();

        PrintPosition(r);
        
        var thisIsAString = r.ReadUtf8Short();
                
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

        Console.WriteLine("Read {0} bytes from {1} buffer", r.Position, r.Mode);
        
        Assert(byte0, byte.MinValue);
        Assert(byte1, byte.MaxValue);
        Assert(byte2, (byte)128);
        
        Assert(bool0, false);
        Assert(bool1, true);
        
        Assert(char0, char.MinValue);
        Assert(char1, char.MaxValue);
        Assert(char2, (char)128);
        
        Assert(thisIsAString, "This is a string");
        
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
    }

    private static void PrintPosition(Reader r, [CallerLineNumber] int line = 0)
    {
        Console.WriteLine("Position: {0} at {1}", r.Position, line);
    }
    private static void PrintPosition(Writer w, [CallerLineNumber] int line = 0)
    {
        Console.WriteLine("Position: {0} at {1}", w.Position, line);
    }
    private static void Assert(byte value, byte expected) {
        Console.WriteLine("Byte value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
    private static void Assert(bool value, bool expected) {
        Console.WriteLine("Bool value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
    private static void Assert(char value, char expected) {
        Console.WriteLine("Char value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
    private static void Assert(short value, short expected) {
        Console.WriteLine("Short value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
    private static void Assert(ushort value, ushort expected) {
        Console.WriteLine("Ushort value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
    private static void Assert(int value, int expected) {
        Console.WriteLine("Int value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
    private static void Assert(uint value, uint expected) {
        Console.WriteLine("UInt value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
    private static void Assert(long value, long expected) {
        Console.WriteLine("Long value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
    private static void Assert(ulong value, ulong expected) {
        Console.WriteLine("ULong value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
    private static void Assert(float value, float expected) {
        Console.WriteLine("Float value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
    private static void Assert(double value, double expected) {
        Console.WriteLine("Double value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
    private static void Assert(string value, string expected) {
        Console.WriteLine("String value: {0}, Expected: {1}, Is Same: {2}", value, expected, value == expected);
    }
}