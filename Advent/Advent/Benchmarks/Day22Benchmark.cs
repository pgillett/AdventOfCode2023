using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day22Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day22();
        day.Part1(InputData.Day22);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day22();
        day.Part2(InputData.Day22);
    }
}
