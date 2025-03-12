### Results

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5487/22H2/2022Update)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


| Method           | Mode   | Mean      | Error     | StdDev    |
|----------------- |------- |----------:|----------:|----------:|
| WriteByte        | Little | 11.896 ns | 0.0630 ns | 0.0559 ns |
| WriteBoolean     | Little |  7.045 ns | 0.0272 ns | 0.0227 ns |
| WriteChar        | Little | 25.285 ns | 0.0561 ns | 0.0438 ns |
| WriteShort       | Little | 20.585 ns | 0.3195 ns | 0.2832 ns |
| WriteUShort      | Little | 20.657 ns | 0.1429 ns | 0.1193 ns |
| WriteInt         | Little | 20.176 ns | 0.1489 ns | 0.1320 ns |
| WriteUInt        | Little | 27.926 ns | 0.2390 ns | 0.2119 ns |
| WriteLong        | Little | 19.788 ns | 0.3151 ns | 0.2794 ns |
| WriteULong       | Little | 19.119 ns | 0.0425 ns | 0.0377 ns |
| WriteFloat       | Little | 31.777 ns | 0.1122 ns | 0.0937 ns |
| WriteDouble      | Little | 41.968 ns | 0.3945 ns | 0.3294 ns |
| WriteStringShort | Little | 98.529 ns | 1.9572 ns | 1.8308 ns |
| WriteStringInt   | Little | 98.637 ns | 1.9556 ns | 1.8293 ns |
| WriteByte        | Big    | 11.845 ns | 0.0360 ns | 0.0281 ns |
| WriteBoolean     | Big    |  7.301 ns | 0.0414 ns | 0.0367 ns |
| WriteChar        | Big    | 25.501 ns | 0.2902 ns | 0.2715 ns |
| WriteShort       | Big    | 20.722 ns | 0.4349 ns | 0.4068 ns |
| WriteUShort      | Big    | 20.478 ns | 0.2077 ns | 0.1735 ns |
| WriteInt         | Big    | 20.216 ns | 0.3046 ns | 0.2849 ns |
| WriteUInt        | Big    | 32.421 ns | 0.3313 ns | 0.3099 ns |
| WriteLong        | Big    | 29.554 ns | 0.2985 ns | 0.2646 ns |
| WriteULong       | Big    | 37.526 ns | 0.6671 ns | 0.6240 ns |
| WriteFloat       | Big    | 33.624 ns | 0.3899 ns | 0.3456 ns |
| WriteDouble      | Big    | 40.875 ns | 0.4678 ns | 0.4376 ns |
| WriteStringShort | Big    | 97.075 ns | 0.8205 ns | 0.7274 ns |
| WriteStringInt   | Big    | 99.420 ns | 1.9797 ns | 1.9443 ns |
