using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day18Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day18();
        day.Part1(InputData.Day18);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day18();
        day.Part2(InputData.Day18);
    }
}
