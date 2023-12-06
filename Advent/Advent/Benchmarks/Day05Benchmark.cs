using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day05Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day05();
        day.Part1(InputData.Day05);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day05();
        day.Part2(InputData.Day05);
    }

}