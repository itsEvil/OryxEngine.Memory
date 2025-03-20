BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5608/22H2/2022Update)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.100
[Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


| Method        | Mode   | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------- |------- |----------:|----------:|----------:|-------:|----------:|
| ReadByte      | Little |  9.994 ns | 0.0565 ns | 0.0472 ns |      - |         - |
| ReadBoolean   | Little |  8.175 ns | 0.0879 ns | 0.0822 ns |      - |         - |
| ReadShort     | Little | 19.966 ns | 0.1877 ns | 0.1756 ns |      - |         - |
| ReadUShort    | Little | 17.041 ns | 0.2501 ns | 0.2339 ns |      - |         - |
| ReadInt       | Little | 20.282 ns | 0.1702 ns | 0.1592 ns |      - |         - |
| ReadUInt      | Little | 17.538 ns | 0.3868 ns | 0.4139 ns |      - |         - |
| ReadLong      | Little | 20.070 ns | 0.1085 ns | 0.0906 ns |      - |         - |
| ReadULong     | Little | 18.662 ns | 0.1854 ns | 0.1644 ns |      - |         - |
| ReadFloat     | Little | 15.153 ns | 0.0437 ns | 0.0388 ns |      - |         - |
| ReadDouble    | Little | 17.587 ns | 0.1440 ns | 0.1277 ns |      - |         - |
| ReadString    | Little | 94.603 ns | 1.9156 ns | 1.4955 ns | 0.1122 |     352 B |
| ReadStringInt | Little | 91.846 ns | 0.9905 ns | 0.8271 ns | 0.1122 |     352 B |
| ReadByte      | Big    |  9.320 ns | 0.0693 ns | 0.0648 ns |      - |         - |
| ReadBoolean   | Big    |  7.378 ns | 0.0800 ns | 0.0709 ns |      - |         - |
| ReadShort     | Big    | 19.561 ns | 0.1663 ns | 0.1556 ns |      - |         - |
| ReadUShort    | Big    | 17.837 ns | 0.2436 ns | 0.2279 ns |      - |         - |
| ReadInt       | Big    | 20.065 ns | 0.1898 ns | 0.1682 ns |      - |         - |
| ReadUInt      | Big    | 20.725 ns | 0.1484 ns | 0.1388 ns |      - |         - |
| ReadLong      | Big    | 19.210 ns | 0.1201 ns | 0.1065 ns |      - |         - |
| ReadULong     | Big    | 17.995 ns | 0.2217 ns | 0.1965 ns |      - |         - |
| ReadFloat     | Big    | 15.585 ns | 0.0501 ns | 0.0391 ns |      - |         - |
| ReadDouble    | Big    | 16.393 ns | 0.1059 ns | 0.0885 ns |      - |         - |
| ReadString    | Big    | 91.798 ns | 1.8759 ns | 3.1855 ns | 0.1122 |     352 B |
| ReadStringInt | Big    | 88.277 ns | 1.6935 ns | 1.7391 ns | 0.1122 |     352 B |