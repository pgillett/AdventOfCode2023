using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day09Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day09();
        day.Part1(InputData.Day09);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day09();
        day.Part2(InputData.Day09);
    }

}
