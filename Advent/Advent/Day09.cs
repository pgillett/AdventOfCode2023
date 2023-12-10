using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day09
{
    public int Part1(string input) =>
        input.Split(Environment.NewLine)
            .Sum(l => CalcEnd(l.Split(' ').Select(int.Parse).ToArray()));

    private int CalcEnd(int[] history)
    {
        for (var a = history.Length - 1; a >= 0; a--)
        {
            var allZero = true;
            for (var b = 0; b < a; b++)
            {
                var prev = history[b];
                if (prev != 0)
                    allZero = false;
                history[b] = history[b + 1] - prev;
            }

            if (allZero)
                break;
        }

        return history.Sum();
    }

    public int Part2(string input) =>
        input.Split(Environment.NewLine)
            .Sum(l => CalcStart(l.Split(' ').Select(int.Parse).ToArray()));

    public int CalcStart(int[] history)
    {
        var first = 0;
        var flip = true;
        for (var a = history.Length - 1; a >= 0; a--)
        {
            flip = !flip;
            first = -first + history[0];
            var allZero = true;
            for (var b = 0; b < a; b++)
            {
                history[b] = history[b + 1] - history[b];
                if (history[b] != 0)
                    allZero = false;
            }

            if (allZero)
                break;
        }

        if (flip) first = -first;

        return first;

    }
}