### Results 

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5487/22H2/2022Update)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


| Method           | Mode   | Mean       | Error     | StdDev    | Gen0   | Allocated |
|----------------- |------- |-----------:|----------:|----------:|-------:|----------:|
| WriteByte        | Little |  12.412 ns | 0.1259 ns | 0.1178 ns |      - |         - |
| WriteBoolean     | Little |   7.026 ns | 0.0463 ns | 0.0387 ns |      - |         - |
| WriteChar        | Little |  24.998 ns | 0.1073 ns | 0.0951 ns |      - |         - |
| WriteShort       | Little |  20.448 ns | 0.2868 ns | 0.2683 ns |      - |         - |
| WriteUShort      | Little |  22.198 ns | 0.1075 ns | 0.0953 ns |      - |         - |
| WriteInt         | Little |  24.899 ns | 0.4590 ns | 0.4294 ns |      - |         - |
| WriteUInt        | Little |  27.790 ns | 0.1724 ns | 0.1528 ns |      - |         - |
| WriteLong        | Little |  23.735 ns | 0.1923 ns | 0.1799 ns |      - |         - |
| WriteULong       | Little |  27.320 ns | 0.2392 ns | 0.2121 ns |      - |         - |
| WriteFloat       | Little |  34.126 ns | 0.5605 ns | 0.5243 ns |      - |         - |
| WriteDouble      | Little |  40.823 ns | 0.8528 ns | 0.7977 ns |      - |         - |
| WriteStringShort | Little | 102.217 ns | 1.2639 ns | 1.1204 ns | 0.0637 |     200 B |
| WriteStringInt   | Little |  99.121 ns | 0.6827 ns | 0.6052 ns | 0.0637 |     200 B |
| WriteByte        | Big    |  11.925 ns | 0.0881 ns | 0.0736 ns |      - |         - |
| WriteBoolean     | Big    |   8.216 ns | 0.1298 ns | 0.1215 ns |      - |         - |
| WriteChar        | Big    |  25.883 ns | 0.1105 ns | 0.0923 ns |      - |         - |
| WriteShort       | Big    |  27.926 ns | 0.2302 ns | 0.2041 ns |      - |         - |
| WriteUShort      | Big    |  27.380 ns | 0.1283 ns | 0.1071 ns |      - |         - |
| WriteInt         | Big    |  29.958 ns | 0.4632 ns | 0.4332 ns |      - |         - |
| WriteUInt        | Big    |  19.381 ns | 0.1110 ns | 0.1039 ns |      - |         - |
| WriteLong        | Big    |  27.993 ns | 0.1424 ns | 0.1112 ns |      - |         - |
| WriteULong       | Big    |  37.248 ns | 0.5859 ns | 0.5194 ns |      - |         - |
| WriteFloat       | Big    |  31.432 ns | 0.1600 ns | 0.1249 ns |      - |         - |
| WriteDouble      | Big    |  41.841 ns | 0.1478 ns | 0.1234 ns |      - |         - |
| WriteStringShort | Big    | 104.516 ns | 0.6944 ns | 0.5422 ns | 0.0637 |     200 B |
| WriteStringInt   | Big    |  99.569 ns | 0.4668 ns | 0.3898 ns | 0.0637 |     200 B |

