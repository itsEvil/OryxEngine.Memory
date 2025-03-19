using System.Diagnostics;

// ReSharper disable once CheckNamespace
namespace Tests;

public static class Entry {
    public static void Main(string[] args) {
        //This tester class creates a Reader and Writer for big Little and Big endian
        //Then asserts the values from the buffer vs expected values 
        _ = new Tester();
        Console.WriteLine("Finished");
        Debug.WriteLine("Finished");
    }
}