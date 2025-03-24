BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5608/22H2/2022Update)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.100
[Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


| Method        | Mode   | Mean      | Error     | StdDev    | Median    | Gen0   | Allocated |
|-------------- |------- |----------:|----------:|----------:|----------:|-------:|----------:|
| ReadByte      | Little | 10.016 ns | 0.1325 ns | 0.1239 ns | 10.044 ns |      - |         - |
| ReadBoolean   | Little |  8.081 ns | 0.1077 ns | 0.1007 ns |  8.080 ns |      - |         - |
| ReadShort     | Little | 20.578 ns | 0.1775 ns | 0.1573 ns | 20.563 ns |      - |         - |
| ReadUShort    | Little | 20.664 ns | 0.0601 ns | 0.0533 ns | 20.675 ns |      - |         - |
| ReadInt       | Little | 19.811 ns | 0.2013 ns | 0.1883 ns | 19.828 ns |      - |         - |
| ReadUInt      | Little | 19.726 ns | 0.0730 ns | 0.0683 ns | 19.735 ns |      - |         - |
| ReadLong      | Little | 26.324 ns | 0.4970 ns | 0.4649 ns | 26.315 ns |      - |         - |
| ReadULong     | Little | 20.207 ns | 0.2066 ns | 0.1831 ns | 20.230 ns |      - |         - |
| ReadFloat     | Little | 20.632 ns | 0.1180 ns | 0.1046 ns | 20.608 ns |      - |         - |
| ReadDouble    | Little | 20.403 ns | 0.1653 ns | 0.1546 ns | 20.403 ns |      - |         - |
| ReadString    | Little | 87.480 ns | 1.5458 ns | 3.8780 ns | 85.775 ns | 0.1122 |     352 B |
| ReadStringInt | Little | 80.536 ns | 0.3826 ns | 0.3392 ns | 80.629 ns | 0.1122 |     352 B |
| ReadByte      | Big    | 10.468 ns | 0.0507 ns | 0.1234 ns | 10.456 ns |      - |         - |
| ReadBoolean   | Big    |  8.035 ns | 0.0473 ns | 0.0443 ns |  8.033 ns |      - |         - |
| ReadShort     | Big    | 22.663 ns | 0.0967 ns | 0.0857 ns | 22.668 ns |      - |         - |
| ReadUShort    | Big    | 23.129 ns | 0.1514 ns | 0.1417 ns | 23.165 ns |      - |         - |
| ReadInt       | Big    | 20.283 ns | 0.1005 ns | 0.0940 ns | 20.297 ns |      - |         - |
| ReadUInt      | Big    | 20.553 ns | 0.1052 ns | 0.0933 ns | 20.557 ns |      - |         - |
| ReadLong      | Big    | 27.674 ns | 0.2343 ns | 0.2191 ns | 27.715 ns |      - |         - |
| ReadULong     | Big    | 21.937 ns | 0.0942 ns | 0.0881 ns | 21.965 ns |      - |         - |
| ReadFloat     | Big    | 21.300 ns | 0.2970 ns | 0.2778 ns | 21.260 ns |      - |         - |
| ReadDouble    | Big    | 22.210 ns | 0.0829 ns | 0.0692 ns | 22.191 ns |      - |         - |
| ReadString    | Big    | 88.202 ns | 1.4494 ns | 2.9278 ns | 86.850 ns | 0.1122 |     352 B |
| ReadStringInt | Big    | 81.422 ns | 0.4744 ns | 0.4205 ns | 81.415 ns | 0.1122 |     352 B |
