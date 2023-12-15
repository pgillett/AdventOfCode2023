using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day14Benchmark
{
    // [Benchmark]
    // public void Part1()
    // {
    //     var day = new Day14();
    //     day.Part1(InputData.Day14);
    // }
    //
    [Benchmark]
    public void Part2()
    {
        var day = new Day14();
        day.Part2(InputData.Day14);
    }

    // [Benchmark]
    // public void Part2Million()
    // {
    //     var day = new Day14();
    //     day.Part2Speed(InputData.Day14);
    // }
}
