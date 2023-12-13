using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day12Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day12();
        day.Part1(InputData.Day12);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day12();
        day.Part2(InputData.Day12);
    }

}
