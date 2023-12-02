﻿using System;
using System.Diagnostics;

namespace Advent;

class Program
{
    private static Stopwatch _stopwatch;

    private const int From = 1;
    private const int To = 25;

    private static readonly int[,] Times = new int[25, 2];

    static void Main(string[] args)
    {
        _stopwatch = new Stopwatch();

        if (IncludeDay(1))
        {
            var day1 = new Day01();
            Output(1, 1, "Calibration sum", day1.CalibrationSum(InputData.Day01));
            Output(1, 2, "Calibration with words", day1.CalibrationSumLetters(InputData.Day01));
        }
        
        if (IncludeDay(2))
        {
            var day2 = new Day02();
            Output(2, 1, "Part 1", day2.Part1(InputData.Day02));
            Output(2, 2, "Part 2", day2.Part2(InputData.Day02));
        }
        
        if (IncludeDay(3))
        {
            var day3 = new Day03();
            Output(3, 1, "Part 1", day3.Part1(InputData.Day03));
            Output(3, 2, "Part 2", day3.Part2(InputData.Day03));
        }
        
        if (IncludeDay(4))
        {
            var day4 = new Day04();
            Output(4, 1, "Part 1", day4.Part1(InputData.Day04));
            Output(4, 2, "Part 2", day4.Part2(InputData.Day04));
        }
        
        if (IncludeDay(5))
        {
            var day5 = new Day05();
            Output(5, 1, "Part 1", day5.Part1(InputData.Day05));
            Output(5, 2, "Part 2", day5.Part2(InputData.Day05));
        }
        
        if (IncludeDay(6))
        {
            var day6 = new Day06();
            Output(6, 1, "Part 1", day6.Part1(InputData.Day06));
            Output(6, 2, "Part 2", day6.Part2(InputData.Day06));
        }
        
        if (IncludeDay(7))
        {
            var day7 = new Day07();
            Output(7, 1, "Part 1", day7.Part1(InputData.Day07));
            Output(7, 2, "Part 2", day7.Part2(InputData.Day07));
        }
        
        if (IncludeDay(8))
        {
            var day8 = new Day08();
            Output(8, 1, "Part 1", day8.Part1(InputData.Day08));
            Output(8, 2, "Part 2", day8.Part2(InputData.Day08));
        }
        
        if (IncludeDay(9))
        {
            var day9 = new Day09();
            Output(9, 1, "Part 1", day9.Part1(InputData.Day09));
            Output(9, 2, "Part 2", day9.Part2(InputData.Day09));
        }
        
        if (IncludeDay(10))
        {
            var day10 = new Day10();
            Output(10, 1, "Part 1", day10.Part1(InputData.Day10));
            Output(10, 2, "Part 2", day10.Part2(InputData.Day10));
        }
        
        if (IncludeDay(11))
        {
            var day11 = new Day11();
            Output(11, 1, "Part 1", day11.Part1(InputData.Day11));
            Output(11, 2, "Part 2", day11.Part2(InputData.Day11));
        }
        
        if (IncludeDay(12))
        {
            var day11 = new Day12();
            Output(12, 1, "Part 1", day11.Part1(InputData.Day12));
            Output(12, 2, "Part 2", day11.Part2(InputData.Day12));
        }
        
        if (IncludeDay(13))
        {
            var day13 = new Day13();
            Output(13, 1, "Part 1", day13.Part1(InputData.Day13));
            Output(13, 2, "Part 2", day13.Part2(InputData.Day13));
        }
        
        if (IncludeDay(14))
        {
            var day14 = new Day14();
            Output(14, 1, "Part 1", day14.Part1(InputData.Day14));
            Output(14, 2, "Part 2", day14.Part2(InputData.Day14));
        }
        
        if (IncludeDay(15))
        {
            var day15 = new Day15();
            Output(15, 1, "Part 1", day15.Part1(InputData.Day15));
            Output(15, 2, "Part 2", day15.Part2(InputData.Day15));
        }
        
        if (IncludeDay(16))
        {
            var day16 = new Day16();
            Output(16, 1, "Part 1", day16.Part1(InputData.Day16));
            Output(16, 2, "Part 2", day16.Part2(InputData.Day16));
        }
        
        if (IncludeDay(17))
        {
            var day17 = new Day17();
            Output(17, 1, "Part 1", day17.Part1(InputData.Day17));
            Output(17, 2, "Part 2", day17.Part2(InputData.Day17));
        }
        
        if (IncludeDay(18))
        {
            var day18 = new Day18();
            Output(18, 1, "Part 1", day18.Part1(InputData.Day18));
            Output(18, 2, "Part 2", day18.Part2(InputData.Day18));
        }
        
        if (IncludeDay(19))
        {
            var day19 = new Day19();
            Output(19, 1, "Part 1", day19.Part1(InputData.Day19));
            Output(19, 2, "Part 2", day19.Part2(InputData.Day19));
        }
        
        if (IncludeDay(20))
        {
            var day20 = new Day20();
            Output(20, 1, "Part 1", day20.Part1(InputData.Day20));
            Output(20, 2, "Part 2", day20.Part2(InputData.Day20));
        }
        
        if (IncludeDay(21))
        {
            var day21 = new Day21();
            Output(21, 1, "Part 1", day21.Part1(InputData.Day21));
            Output(21, 2, "Part 2", day21.Part2(InputData.Day21));
        }
        
        if (IncludeDay(22))
        {
            var day22 = new Day22();
            Output(22, 1, "Part 1", day22.Part1(InputData.Day22));
            Output(22, 2, "Part 2", day22.Part2(InputData.Day22));
        }
        
        if (IncludeDay(23))
        {
            var day23 = new Day23();
            Output(23, 1, "Part 1", day23.Part1(InputData.Day23));
            Output(23, 2, "Part 2", day23.Part2(InputData.Day23));
        }
        
        if (IncludeDay(24))
        {
            var day24 = new Day24();
            Output(24, 1, "Part 1", day24.Part1(InputData.Day24));
            Output(24, 2, "Part 2", day24.Part2(InputData.Day24));
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
            if (IncludeDay(i + 1))
                Console.WriteLine($"{i + 1,-10}{Times[i, 0],5} ms  {Times[i, 1],5} ms");
        }
    }

    static bool IncludeDay(int day)
    {
        if (DateTime.Now < new DateTime(2023, 12, day)) return false;
        
        if (day < From || day > To) return false;

        _stopwatch.Reset();
        _stopwatch.Start();
        Console.WriteLine();
        Console.WriteLine($"DAY {day}");
        Console.WriteLine($"==========");

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