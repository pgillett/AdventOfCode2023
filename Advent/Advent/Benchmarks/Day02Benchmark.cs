using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day02Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day02();
        day.Sums(InputData.Day02);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day02();
        day.Powers(InputData.Day02);
    }

}