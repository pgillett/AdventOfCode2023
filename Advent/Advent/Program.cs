using System;
using System.Diagnostics;
using Advent.Benchmarks;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace Advent;

class Program
{
    private static Stopwatch _stopwatch;

    private const int From = 23;
    private const int To = 23;

    private static readonly int[,] Times = new int[25, 2];

    static void Main(string[] args)
    {
        _stopwatch = new Stopwatch();

        // var config = ManualConfig.Create(DefaultConfig.Instance)
        //     .WithOptions(ConfigOptions.JoinSummary)
        //     .WithOptions(ConfigOptions.DisableLogFile);
        //
        // BenchmarkRunner.Run(new[]
        // {
        //     BenchmarkConverter.TypeToBenchmarks(typeof(Day01Benchmark), config),
        //     BenchmarkConverter.TypeToBenchmarks(typeof(Day02Benchmark), config),
        //     // BenchmarkConverter.TypeToBenchmarks(typeof(Day03Benchmark)),
        //     // BenchmarkConverter.TypeToBenchmarks(typeof(Day04Benchmark)),
        //     // BenchmarkConverter.TypeToBenchmarks(typeof(Day05Benchmark)),
        //     // BenchmarkConverter.TypeToBenchmarks(typeof(Day06Benchmark)),
        // });
        //
        // BenchmarkRunner.Run<ParsingBenchmark>();
        //
        // return;
        //
        if (IncludeDay(1))
        {
            BenchmarkRunner.Run<Day01Benchmark>();
        }
        
        if (IncludeDay(2))
        {
            BenchmarkRunner.Run<Day02Benchmark>();
        }
        
        if (IncludeDay(3))
        {
            BenchmarkRunner.Run<Day03Benchmark>();
        }
        
        if (IncludeDay(4))
        {
            BenchmarkRunner.Run<Day04Benchmark>();
        }
        
        if (IncludeDay(5))
        {
            BenchmarkRunner.Run<Day05Benchmark>();
        }
        
        if (IncludeDay(6))
        {
            BenchmarkRunner.Run<Day06Benchmark>();
        }
        
        if (IncludeDay(7))
        {
            BenchmarkRunner.Run<Day07Benchmark>();
        }
        
        if (IncludeDay(8))
        {
            BenchmarkRunner.Run<Day08Benchmark>();
        }
        
        if (IncludeDay(9))
        {
            BenchmarkRunner.Run<Day09Benchmark>();
        }
        
        if (IncludeDay(10))
        {
            BenchmarkRunner.Run<Day10Benchmark>();
        }
        
        if (IncludeDay(11))
        {
            BenchmarkRunner.Run<Day11Benchmark>();
        }
        
        if (IncludeDay(12))
        {
            BenchmarkRunner.Run<Day12Benchmark>();
        }
        
        if (IncludeDay(13))
        {
            BenchmarkRunner.Run<Day13Benchmark>();
        }
        
        if (IncludeDay(14))
        {
            BenchmarkRunner.Run<Day14Benchmark>();
        }
        
        if (IncludeDay(15))
        {
            BenchmarkRunner.Run<Day15Benchmark>();
        }
        
        if (IncludeDay(16))
        {
            BenchmarkRunner.Run<Day16Benchmark>();
        }
        
        if (IncludeDay(17))
        {
            BenchmarkRunner.Run<Day17Benchmark>();
        }
        
        if (IncludeDay(18))
        {
            BenchmarkRunner.Run<Day18Benchmark>();
        }
        
        if (IncludeDay(19))
        {
            BenchmarkRunner.Run<Day19Benchmark>();
        }
        
        if (IncludeDay(20))
        {
            //BenchmarkRunner.Run<Day20Benchmark>();
        }
        
        if (IncludeDay(21))
        {
            //BenchmarkRunner.Run<Day21Benchmark>();
        }
        
        if (IncludeDay(22))
        {
            BenchmarkRunner.Run<Day22Benchmark>();
        }
        
        if (IncludeDay(23))
        {
            BenchmarkRunner.Run<Day23Benchmark>();
        }
        
        if (IncludeDay(24))
        {
            //BenchmarkRunner.Run<Day24Benchmark>();
        }
        
        if (IncludeDay(25))
        {
            var day25 = new Day25();
            Output(25, 1, "Part 1", day25.Part1(InputData.Day25));
            Output(25, 2, "Part 2", day25.Part2(InputData.Day25));
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Day       Part 1    Part 2");
        for (int i = 0; i < 25; i++)
        {
            if (IncludeDay(i + 1, false))
                Console.WriteLine($"{i + 1,-10}{Times[i, 0],5} ms  {Times[i, 1],5} ms");
        }
    }

    static bool IncludeDay(int day, bool header = true)
    {
        if (DateTime.Now < new DateTime(2023, 12, day)) return false;
        
        if (day < From || day > To) return false;

        _stopwatch.Reset();
        _stopwatch.Start();
        if (header)
        {
            Console.WriteLine();
            Console.WriteLine($"DAY {day}");
            Console.WriteLine($"==========");
        }

        return true;
    }

    static void Output(int day, int part, string name, object answer)
    {
        var time = _stopwatch.ElapsedMilliseconds;
        Times[day - 1, part - 1] = (int) time;
        Console.WriteLine($"{time} ms - {name}: {answer}");
        _stopwatch.Reset();
        _stopwatch.Start();
    }
}
