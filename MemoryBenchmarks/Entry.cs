using BenchmarkDotNet.Running;

namespace MemoryBenchmarks;

public static class Entry
{
    public static void Main(string[] args)
    {
        //Debug();
        
        //BenchmarkRunner.Run<WriterBenchmarks>();
        //BenchmarkRunner.Run<ReaderBenchmarks>();
        BenchmarkRunner.Run<ReaderBenchmarksStrings>();
    }
    private static void Debug()
    {
        //Used to figured out positions for Reading strings
        var b = new ReaderBenchmarks();
        b.Setup();
        b.ReadString();
        b.ReadStringInt();
    }
}