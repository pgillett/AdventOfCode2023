using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day16Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day16();
        day.Part1(InputData.Day16);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day16();
        day.Part2(InputData.Day16);
    }
}
