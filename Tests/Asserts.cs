using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using OryxEngine.Memory;

namespace Tests;

public static class Asserts
{
    private const bool ShowPositions = false;
    private const bool ShowValues = false;

    public const int WriterIndex = 0;
    public const int ReaderIndex = 1;
    private static readonly int[] LastPositions = [0,0];
    
    public static string Prefix = "";
    private static int AssertCount = 0;
    private static int PassedCount = 0;
    
    public static void ResetPositions(int index) => LastPositions[index] = 0;

    private static void PrintBytes(char c)
    {
        Span<byte> bytes = stackalloc byte[2];
        BitConverter.TryWriteBytes(bytes, c);

        var sb = new StringBuilder();
        foreach (var b in bytes)
        {
            sb.Append(b);
            sb.Append(',');
        }
        
        Console.WriteLine("Bytes: {0}", sb);
    }
    private static void PrintBytes(string value) {
        var bytes = Encoding.UTF8.GetBytes(value);
        Console.WriteLine("Bytes: {0}", string.Join(',', bytes));
    }
    public static void PrintPosition(Reader r, [CallerLineNumber] int line = 0)
    {
        if (!ShowPositions)
            return;
        
        Console.WriteLine("Position: {0} at line {1}, difference: {2}", r.Position, line, r.Position - LastPositions[ReaderIndex]);
        LastPositions[ReaderIndex] = r.Position;
    }
    public static void PrintPosition(Writer w, [CallerLineNumber] int line = 0) {
        if (!ShowPositions)
            return;
        
        Console.WriteLine("Position: {0} at {1}, difference: {2}", w.Position, line, w.Position - LastPositions[WriterIndex]);
        LastPositions[WriterIndex] = w.Position;
    }
    public static void PrintCounts()
    {
        var result = PassedCount == AssertCount;
        Console.Write("Asserts: ");
        Console.ForegroundColor = result ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine("{0} / {1}", PassedCount, AssertCount);
        Console.ResetColor();
    }
    private static void PrintResult(string v0 = "", string v1 = "", string title = "", bool result = false)
    {
        AssertCount++;
        if (result)
            PassedCount++;
        
        if (ShowValues)
        {
            Console.Write("{3}{0} Actual: {1}, Expected: {2}, Result: ", title, v0, v1, Prefix);
            Console.ForegroundColor = result ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(result ? "Passed" : "Failed");
            Console.ResetColor();
        }
        else
        {
            Console.Write("Assert {1}{0} | Result: ", title, Prefix);
            Console.ForegroundColor = result ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(result ? "Passed" : "Failed");
            Console.ResetColor();
        }
    }
    public static void Assert(byte value, byte expected) {
        PrintResult(value.ToString(), expected.ToString(), "Byte", value == expected);
    }
    public static void Assert(bool value, bool expected) {
        PrintResult(value.ToString(), expected.ToString(), "Bool", value == expected);
    }
    public static void Assert(short value, short expected) {
        PrintResult(value.ToString(), expected.ToString(), "Short", value == expected);
    }
    public static void Assert(ushort value, ushort expected) {
        PrintResult(value.ToString(), expected.ToString(), "UShort", value == expected);
    }
    public static void Assert(int value, int expected) {
        PrintResult(value.ToString(), expected.ToString(), "Int", value == expected);
    }
    public static void Assert(uint value, uint expected) {
        PrintResult(value.ToString(), expected.ToString(), "UInt", value == expected);
    }
    public static void Assert(long value, long expected) {
        PrintResult(value.ToString(), expected.ToString(), "Long", value == expected);
    }
    public static void Assert(ulong value, ulong expected) {
        PrintResult(value.ToString(), expected.ToString(), "ULong", value == expected);
    }
    public static void Assert(float value, float expected) {
        PrintResult(value.ToString(CultureInfo.CurrentCulture), expected.ToString(CultureInfo.CurrentCulture), "Float", value == expected);
    }
    public static void Assert(double value, double expected) {
        PrintResult(value.ToString(CultureInfo.CurrentCulture), expected.ToString(CultureInfo.CurrentCulture), "Double", value == expected);
    }
    public static void Assert(string value, string expected) {
        PrintResult(value, expected, "Byte", string.Equals(value, expected));
    }
}