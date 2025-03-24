BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5608/22H2/2022Update)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.100
[Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


| Method         | Mode   | Mean      | Error     | StdDev    | Allocated |
|--------------- |------- |----------:|----------:|----------:|----------:|
| WriteByte      | Little | 16.727 ns | 0.1335 ns | 0.1183 ns |         - |
| WriteBoolean   | Little |  9.807 ns | 0.1315 ns | 0.1230 ns |         - |
| WriteShort     | Little | 22.188 ns | 0.1577 ns | 0.1475 ns |         - |
| WriteUShort    | Little | 22.533 ns | 0.1572 ns | 0.1471 ns |         - |
| WriteInt       | Little | 22.202 ns | 0.1486 ns | 0.1390 ns |         - |
| WriteUInt      | Little | 22.197 ns | 0.1026 ns | 0.0856 ns |         - |
| WriteLong      | Little | 22.466 ns | 0.2721 ns | 0.2545 ns |         - |
| WriteULong     | Little | 33.236 ns | 0.2852 ns | 0.2528 ns |         - |
| WriteFloat     | Little | 25.315 ns | 0.2184 ns | 0.2043 ns |         - |
| WriteDouble    | Little | 22.083 ns | 0.1169 ns | 0.0976 ns |         - |
| WriteString    | Little | 46.983 ns | 0.2574 ns | 0.2408 ns |         - |
| WriteStringInt | Little | 36.887 ns | 0.2187 ns | 0.1826 ns |         - |
| WriteByte      | Big    | 13.669 ns | 0.1463 ns | 0.1297 ns |         - |
| WriteBoolean   | Big    |  9.508 ns | 0.1652 ns | 0.1546 ns |         - |
| WriteShort     | Big    | 23.616 ns | 0.1704 ns | 0.1594 ns |         - |
| WriteUShort    | Big    | 26.385 ns | 0.1949 ns | 0.1728 ns |         - |
| WriteInt       | Big    | 23.074 ns | 0.2543 ns | 0.2255 ns |         - |
| WriteUInt      | Big    | 22.867 ns | 0.3522 ns | 0.3295 ns |         - |
| WriteLong      | Big    | 22.864 ns | 0.3933 ns | 0.3679 ns |         - |
| WriteULong     | Big    | 22.941 ns | 0.3109 ns | 0.2909 ns |         - |
| WriteFloat     | Big    | 22.992 ns | 0.3077 ns | 0.2878 ns |         - |
| WriteDouble    | Big    | 23.000 ns | 0.3568 ns | 0.3337 ns |         - |
| WriteString    | Big    | 47.947 ns | 0.2877 ns | 0.2692 ns |         - |
| WriteStringInt | Big    | 38.239 ns | 0.2362 ns | 0.2094 ns |         - |