using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day04Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day04();
        day.Part1(InputData.Day04);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day04();
        day.Part2(InputData.Day04);
    }

}