using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day06
{
    public int Part1(string input)
    {
        var split = input.Split(Environment.NewLine);
        var times = split[0][9..].Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        var distances = split[1][9..].Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
     
        var total = 1;
        for (var race = 0; race < times.Length; race++)
        {
            var greater = 0;
            for (var held = 1; held < times[race]; held++)
            {
                if ((times[race] - held) * held > distances[race])
                    greater++;
            }

            total *= greater;
        }
        return total;
    }

    public int Part2Maths(string input)
    {
        var split = input.Split(Environment.NewLine);
        var time = int.Parse(split[0][9..].Replace(" ", ""));
        var distance = long.Parse(split[1][9..].Replace(" ", ""));
        return ResultMaths(time, distance);
    }

    private int ResultMaths(int time, long distance)
    {
        var t = (double)time;
        var r = Math.Ceiling((t - Math.Sqrt(t * t - 4 * distance)) / 2);
        return time - ((int)r) - ((int)r) + 1;
    }
    
    public int Part2NoParse(string input)
    {
        return ResultMaths(49979494, 263153213781851);
    }
    
    public int Part2SearchNoParse(string input)
    {
        return Result(49979494, 263153213781851);
    }
    
    public int Part2(string input)
    {
        var split = input.Split(Environment.NewLine);
        var time = int.Parse(split[0][9..].Replace(" ", ""));
        var distance = long.Parse(split[1][9..].Replace(" ", ""));
        return Result(time, distance);
    }
    
    private int Result(int time, long distance)
    {
        var lower = 0;

        var start = 1;
        var end = time / 2 + 1;

        while (true)
        {
            if (end - start == 1)
            {
                lower = end;
                break;
            }
            var middle = start + (end - start) / 2;
            if (((long)time - middle) * middle > distance)
            {
                end = middle;
            }
            else
            {
                start = middle;
            }
        }

        return (time - lower) - lower + 1;
    }
}