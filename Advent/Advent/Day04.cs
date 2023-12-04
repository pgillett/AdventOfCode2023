using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent;

public class Day04
{
    public int Part1(string input) =>
        Parse(input)
            .Where(matches => matches > 0)
            .Sum(matches => 1 << (matches - 1));

    public int Part2(string input)
    {
        var cards = Parse(input);
        var copies = new int[cards.Length];
        Array.Fill(copies, 1);

        for (var c = 0; c < cards.Length; c++)
        {
            for (var i = 1; i <= cards[c]; i++)
            {
                copies[c + i] += copies[c];
            }
        }

        return copies.Sum();
    }

    private int[] Parse(string input) =>
        input.Split(Environment.NewLine)
            .Select(c => c.Split(':', '|'))
            .Select(c =>
            {
                var numbers = $"{c[2]} ";
                return c[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Count(w => numbers.Contains($" {w} "));
            })
            .ToArray();
}