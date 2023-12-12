using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day11
{
    public long Part1(string input) => Shortest(input, 2);
    
    public long Shortest(string input, int gaps)
    {
        var size = input.IndexOf(Environment.NewLine[0]);
        var lineLength = size + Environment.NewLine.Length;

        var widths = new int[size];
        var heights = new int[size];

        var galaxies = new List<(int y, int x)>();
        
        for (var s = 0; s < size; s++)
        {
            heights[s] = gaps;
            for(var x=0; x<size;x++)
                if (input[s * lineLength + x] == '#')
                {
                    heights[s] = 1;
                    break;
                }
            widths[s] = gaps;
            for(var y=0; y<size;y++)
                if (input[y * lineLength + s] == '#')
                {
                    widths[s] = 1;
                    break;
                }
        }

        {
            var y2 = 0;
            var yStart = 0;
            for (var y = 0; y < size; y++)
            {
                var x2 = 0;
                for (var x = 0; x < size; x++)
                {
                    if (input[yStart + x] == '#')
                        galaxies.Add((y2, x2));
                    x2 += widths[x];
                }
                y2 += heights[y];
                yStart += lineLength;
            }
        }
        
        var total = 0L;

        for (var g1 = 0; g1 < galaxies.Count - 1; g1++)
        {
            for (var g2 = g1 + 1; g2 < galaxies.Count; g2++)
            {
                total += Math.Abs(galaxies[g2].y - galaxies[g1].y)
                        + Math.Abs(galaxies[g2].x - galaxies[g1].x);
            }
        }
        
        return total;
    }
    
    public long Shortest2(string input, int gaps)
    {
        var map = input.Split(Environment.NewLine);

        var size = map.Length;
        
        var widths = new int[size];
        var heights = new int[size];

        var galaxies = new List<(int y, int x)>();
        
        for (var s = 0; s < size; s++)
        {
            heights[s] = gaps;
            for(var x=0; x<size;x++)
                if (map[s][x] == '#')
                {
                    heights[s] = 1;
                    break;
                }
            widths[s] = gaps;
            for(var y=0; y<size;y++)
                if (map[y][s] == '#')
                {
                    widths[s] = 1;
                    break;
                }
        }

        {
            var y2 = 0;
            for (var y = 0; y < size; y++)
            {
                var x2 = 0;
                for (var x = 0; x < size; x++)
                {
                    if (map[y][x] == '#')
                        galaxies.Add((y2, x2));
                    x2 += widths[x];
                }
                y2 += heights[y];
            }
        }

        var total = 0L;
        
        for (var g1 = 0; g1 < galaxies.Count - 1; g1++)
        {
            for (var g2 = g1 + 1; g2 < galaxies.Count; g2++)
            {
                var d = Math.Abs(galaxies[g2].y - galaxies[g1].y)
                        + Math.Abs(galaxies[g2].x - galaxies[g1].x);
                total += d;

            }
        }

        return total;
    }

    public long Part2(string input) => Shortest(input, 1000000);
}