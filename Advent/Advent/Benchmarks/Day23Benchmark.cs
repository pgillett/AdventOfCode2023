using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class Day23Benchmark
{
    [Benchmark]
    public void Part1()
    {
        var day = new Day23();
        day.Part1(InputData.Day23);
    }
    
    [Benchmark]
    public void Part2()
    {
        var day = new Day23();
        day.Part2(InputData.Day23);
    }
    
    [Benchmark]
    public void Map()
    {
        var day = new Day23();
        
        var map = InputData.Day23.Split(Environment.NewLine);

        day.GetNodes(new Day23.Node(0, 1, 0), map, false);
    }
}
