``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22623.1028)
11th Gen Intel Core i5-1135G7 2.40GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|                          Method |         Mean |        Error |        StdDev |     Gen0 |     Gen1 | Allocated |
|-------------------------------- |-------------:|-------------:|--------------:|---------:|---------:|----------:|
|             GenerateUsingRandom |     577.8 ns |     22.82 ns |      65.11 ns |   0.2680 |        - |   1.09 KB |
| RandomStringGeneratorUsingBogus | 982,124.8 ns | 40,466.34 ns | 116,105.53 ns | 128.9063 | 115.2344 | 764.41 KB |
