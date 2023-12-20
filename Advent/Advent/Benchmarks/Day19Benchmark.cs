using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day19Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day19();
        day.Part1(InputData.Day19);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day19();
        day.Part2(InputData.Day19);
    }
}
