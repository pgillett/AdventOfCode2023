using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day01Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day01();
        day.CalibrationSum(InputData.Day01);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day01();
        day.CalibrationSumLetters(InputData.Day01);
    }
    
    [Benchmark]
    public void Part1Tidy()
    {
        var day = new Day01Tidy();
        day.CalibrationSum(InputData.Day01);
    }
    
    [Benchmark]
    public void Part2Tidy()
    {
        var day = new Day01Tidy();
        day.CalibrationSumLetters(InputData.Day01);
    }

}