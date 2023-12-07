using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day06Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day06();
        day.Part1(InputData.Day06);
    }
    
    [Benchmark]
    public void Part2Search()
    {
        var day = new Day06();
        day.Part2(InputData.Day06);
    }
    
    [Benchmark]
    public void Part2Maths()
    {
        var day = new Day06();
        day.Part2Maths(InputData.Day06);
    }

    [Benchmark]
    public void Part2MathsNoParse()
    {
        var day = new Day06();
        day.Part2NoParse(InputData.Day06);
    }
    
    [Benchmark]
    public void Part2SearchNoParse()
    {
        var day = new Day06();
        day.Part2SearchNoParse(InputData.Day06);
    }
}