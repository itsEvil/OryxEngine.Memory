using System.Diagnostics;

namespace MemoryTests;

public static class Entry {
    public static void Main(string[] args) {
        _ = new Tester();
        Console.WriteLine("Finished");
        Debug.WriteLine("Finished");
    }
}