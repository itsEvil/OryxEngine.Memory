BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5608/22H2/2022Update)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.100
[Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


| Method         | Mode   | Mean      | Error     | StdDev    | Allocated |
|--------------- |------- |----------:|----------:|----------:|----------:|
| WriteByte      | Little | 12.439 ns | 0.1428 ns | 0.1335 ns |         - |
| WriteBoolean   | Little |  7.381 ns | 0.1191 ns | 0.1114 ns |         - |
| WriteShort     | Little | 26.975 ns | 0.3233 ns | 0.3024 ns |         - |
| WriteUShort    | Little | 17.472 ns | 0.2259 ns | 0.2113 ns |         - |
| WriteInt       | Little | 29.433 ns | 0.1640 ns | 0.1454 ns |         - |
| WriteUInt      | Little | 21.023 ns | 0.1272 ns | 0.1190 ns |         - |
| WriteLong      | Little | 22.317 ns | 0.1828 ns | 0.1620 ns |         - |
| WriteULong     | Little | 40.612 ns | 0.2103 ns | 0.1864 ns |         - |
| WriteFloat     | Little | 28.976 ns | 0.3901 ns | 0.3258 ns |         - |
| WriteDouble    | Little | 24.668 ns | 0.1164 ns | 0.1031 ns |         - |
| WriteString    | Little | 44.273 ns | 0.2095 ns | 0.1750 ns |         - |
| WriteStringInt | Little | 40.012 ns | 0.4466 ns | 0.3959 ns |         - |
| WriteByte      | Big    | 10.991 ns | 0.1108 ns | 0.0925 ns |         - |
| WriteBoolean   | Big    |  7.548 ns | 0.0456 ns | 0.0381 ns |         - |
| WriteShort     | Big    | 37.297 ns | 0.7745 ns | 1.0070 ns |         - |
| WriteUShort    | Big    | 36.533 ns | 0.1012 ns | 0.0897 ns |         - |
| WriteInt       | Big    | 32.846 ns | 0.6612 ns | 0.6790 ns |         - |
| WriteUInt      | Big    | 23.138 ns | 0.2283 ns | 0.2024 ns |         - |
| WriteLong      | Big    | 36.254 ns | 0.6303 ns | 0.5896 ns |         - |
| WriteULong     | Big    | 25.604 ns | 0.1297 ns | 0.1083 ns |         - |
| WriteFloat     | Big    | 27.390 ns | 0.0840 ns | 0.0656 ns |         - |
| WriteDouble    | Big    | 15.803 ns | 0.1110 ns | 0.0867 ns |         - |
| WriteString    | Big    | 44.689 ns | 0.1026 ns | 0.0857 ns |         - |
| WriteStringInt | Big    | 40.251 ns | 0.3082 ns | 0.2732 ns |         - |
