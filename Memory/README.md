# OryxEngine.Memory
A module from Oryx Engine used to write and read data from a byte buffer.
Made in .NET 9.

### How to use?
- Clone Memory folder into wanted location
- Create a new Reader/Writer and assign a buffer to it.
- Use the IReader/IWriter functions to write data to or read data from the buffer.

### Notes
- Throws Exception when error occurs (OutOfBounds)
- Follows the same version as OryxEngine.Memory.Optionals

### Example

```c#
private static void Main(string[] args) {
    //Initalize objects and buffer
    var buffer = new byte[0x10000];
    var writer = new Writer(EndianMode.Big, buffer);
    var reader = new Reader(EndianMode.Big, buffer);

    //Resets the position and expected length to a certain size
    //In a socket scenario set this to the length of the received data
    reader.Reset(sizeof(int) + sizeof(ushort));

    //Write some data and read it
    writer.Write(100);
    writer.Write(ushort.MaxValue);

    var intValue = reader.ReadInt32();
    var ushortValue = reader.ReadUInt16();

    //Reading out of bounds, this will throw exception!!!
    //Writing out of bounds will also throw exception!!!
    //var byteValue = reader.ReadByte();

    Console.WriteLine("Finished: {0}, {1}, {2}, {3}", intValue, ushortValue, reader.Position, reader.Buffer.Length);
}
``` 
