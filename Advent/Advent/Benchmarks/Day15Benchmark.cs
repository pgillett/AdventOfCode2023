using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day15Benchmark
{
    // [Benchmark]
    // public void Part1()
    // {
    //     var day = new Day15();
    //     day.Part1(InputData.Day15);
    // }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day15();
        day.Part2(InputData.Day15);
    }
}
