using System;
using BenchmarkDotNet.Attributes;

namespace Advent.Benchmarks;

[MemoryDiagnoser]
public class ParsingBenchmark
{
    [Benchmark]
    public void IntParseSmall()
    {
        var a = int.Parse("123");
    }
    
    [Benchmark]
    public void IntParseLarge()
    {
        var a = int.Parse("123456789");
    }
    
    [Benchmark]
    public void IntParseSmallSpan()
    {
        var a = int.Parse("123".AsSpan());
    }
    
    [Benchmark]
    public void IntParseLargeSpan()
    {
        var a = int.Parse("123456789".AsSpan());
    }

    [Benchmark]
    public void SelfIntParseSmall()
    {
        var a = Parsing.Int("123".AsSpan());
    }
    
    [Benchmark]
    public void SelfIntParseLarge()
    {
        var a = Parsing.Int("123456789".AsSpan());
    }

}