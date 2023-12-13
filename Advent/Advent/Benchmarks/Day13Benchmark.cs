using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day13Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day13();
        day.Part1(InputData.Day13);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day13();
        day.Part2(InputData.Day13);
    }

}
