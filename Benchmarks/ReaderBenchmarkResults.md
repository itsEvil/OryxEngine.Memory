BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5608/22H2/2022Update)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.100
[Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


| Method        | Mode   |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|-------------- |------- |----------:|----------:|----------:|-------:|----------:|
| ReadByte      | Little | 11.759 ns | 0.2684 ns | 0.2636 ns |      - |         - |
| ReadBoolean   | Little |  7.877 ns | 0.0440 ns | 0.0412 ns |      - |         - |
| ReadShort     | Little | 18.421 ns | 0.1573 ns | 0.1395 ns |      - |         - |
| ReadUShort    | Little | 16.854 ns | 0.1633 ns | 0.1364 ns |      - |         - |
| ReadInt       | Little | 17.191 ns | 0.2344 ns | 0.2193 ns |      - |         - |
| ReadUInt      | Little | 16.851 ns | 0.0880 ns | 0.0780 ns |      - |         - |
| ReadLong      | Little | 19.714 ns | 0.1575 ns | 0.1397 ns |      - |         - |
| ReadULong     | Little | 17.122 ns | 0.1633 ns | 0.1448 ns |      - |         - |
| ReadFloat     | Little | 20.083 ns | 0.4285 ns | 0.4209 ns |      - |         - |
| ReadDouble    | Little | 19.873 ns | 0.2579 ns | 0.2412 ns |      - |         - |
| ReadString    | Little | 88.612 ns | 1.7471 ns | 4.1181 ns | 0.1122 |     352 B |
| ReadStringInt | Little | 83.950 ns |  1.659 ns | 1.5510 ns | 0.1122 |     352 B |
| ReadByte      | Big    |  9.008 ns | 0.1594 ns | 0.1413 ns |      - |         - |
| ReadBoolean   | Big    |  7.341 ns | 0.1522 ns | 0.1271 ns |      - |         - |
| ReadShort     | Big    | 18.117 ns | 0.2850 ns | 0.2380 ns |      - |         - |
| ReadUShort    | Big    | 17.689 ns | 0.0976 ns | 0.0913 ns |      - |         - |
| ReadInt       | Big    | 17.948 ns | 0.2611 ns | 0.2443 ns |      - |         - |
| ReadUInt      | Big    | 18.070 ns | 0.2227 ns | 0.2083 ns |      - |         - |
| ReadLong      | Big    | 21.488 ns | 0.3957 ns | 0.3701 ns |      - |         - |
| ReadULong     | Big    | 18.133 ns | 0.2329 ns | 0.2064 ns |      - |         - |
| ReadFloat     | Big    | 39.136 ns | 0.5392 ns | 0.5044 ns |      - |         - |
| ReadDouble    | Big    | 45.159 ns | 0.5378 ns | 0.5030 ns |      - |         - |
| ReadString    | Big    | 96.190 ns | 1.2490 ns | 1.1081 ns | 0.1116 |     352 B |
| ReadStringInt | Big    | 83.340 ns | 1.1620 ns | 1.0301 ns | 0.1116 |     352 B |