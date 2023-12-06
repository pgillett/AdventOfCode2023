using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day03Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day03();
        day.SumParts(InputData.Day03);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day03();
        day.GearRatios(InputData.Day03);
    }

}