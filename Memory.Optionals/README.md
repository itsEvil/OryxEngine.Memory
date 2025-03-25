# OryxEngine.Memory.Optionals
A module from Oryx Engine used to write and read data from a byte buffer.
Made in .NET 9.

### How to use?
- Clone Memory folder into wanted location
- Create a new Reader/Writer and assign a buffer to it.
- Use the IReader/IWriter functions to write data to or read data from the buffer.

### Notes
- This package works as a dropping replacement for OryxEngine.Memory with only a few changes
- No longer throws exceptions and instead calls an Action that you pass into Writer/Reader when an error occurs 
- The base classes ReaderBig/ReaderLittle or WriterBig/WriterLittle return Option<T> instead of their respective T 
- Follows the same version as OryxEngine.Memory

### Example

```c#
private static void Main(string[] args) {    
    //Initalize objects and buffer
    var buffer = new byte[0x10000];
    var writer = new Writer(EndianMode.Big, buffer /*, failureCallback */);
    var reader = new Reader(EndianMode.Big, buffer /*, failureCallback */);

    //Resets the position and expected length to a certain size
    //In a socket scenario set this to the length of the received data
    reader.Reset(sizeof(int) + sizeof(ushort));

    //Write some data and read it
    writer.Write(100);
    writer.Write(ushort.MaxValue);

    var intValue = reader.ReadInt32();
    var ushortValue = reader.ReadUInt16();

    //Reading out of bounds, this will call failureCallback!!!
    //Writing out of bounds will also call failureCallback!!!
    //var byteValue = reader.ReadByte();

    Console.WriteLine("Finished: {0}, {1}, {2}, {3}", intValue, ushortValue, reader.Position, reader.Buffer.Length);
}

``` 

Nuget Link: https://www.nuget.org/packages/OryxEngine.Memory.Optionals/1.2.0
