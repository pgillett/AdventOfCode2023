using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day07Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day07();
        day.Part1(InputData.Day07);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day07();
        day.Part2(InputData.Day07);
    }
    
    [Benchmark]
    public void Part2C()
    {
        var day = new Day07Opt();
        day.Part2Opt(InputData.Day07);
    }

}