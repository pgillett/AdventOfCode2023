using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day11Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day11();
        day.Part1(InputData.Day11);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day11();
        day.Part2(InputData.Day11);
    }

}
