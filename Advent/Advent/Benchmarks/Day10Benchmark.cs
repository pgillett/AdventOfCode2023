using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day10Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day10();
        day.Part1(InputData.Day10);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day10();
        day.Part2(InputData.Day10);
    }

}
