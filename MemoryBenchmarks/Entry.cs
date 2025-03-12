using BenchmarkDotNet.Running;

namespace MemoryBenchmarks;

public static class Entry
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<Benchmarks>();
    }
}