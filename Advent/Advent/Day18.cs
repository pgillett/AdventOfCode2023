using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day18
{
    public long Part1(string input) => Parse(input, i => i[0][0], i => int.Parse(i[1]));

    public long Part2(string input) => Parse(input, i => i[2][7],
            i => Convert.ToInt32(i[2].Substring(2, 5), 16));
    
    public long Parse(string input, Func<string[], char> getDirection, Func<string[], int> getDistance)
    {
        var instructions = input.Split(Environment.NewLine)
            .Select(l => l.Split(' ')).ToArray();

        var lines = new List<(int fromY, int fromX, int toY, int toX)>();

        (int y, int x) current  = (0, 0);
        foreach (var i in instructions)
        {
            var distance = getDistance(i);
            switch (getDirection(i))
            {
                case 'R':
                case '0':
                    lines.Add((current.y, current.x, current.y, current.x + distance));
                    current = (current.y, current.x + distance);
                    break;
                case 'D':
                case '1':
                    lines.Add((current.y, current.x, current.y + distance, current.x));
                    current = (current.y + distance, current.x);
                    break;
                case 'L':
                case '2':
                    lines.Add((current.y, current.x - distance, current.y, current.x));
                    current = (current.y, current.x - distance);
                    break;
                case 'U':
                case '3':
                    lines.Add((current.y - distance, current.x, current.y, current.x));
                    current = (current.y - distance, current.x);
                    break;
                default:
                    throw new Exception(i[0]);
            }
        }
        return CalcFill(lines);
    }
    
    private static long CalcFill(List<(int fromY, int fromX, int toY, int toX)> lines)
    {
        var total = 0L;
        var minX = lines.Min(l => int.Min(l.fromX, l.toX));

        var ys = lines.Select(l => l.fromY).Distinct()
            .OrderBy(y => y)
            .ToArray();

        for (var i = 0; i < ys.Length; i++)
        {
            total += CalcLine(lines, ys[i], minX);

            if (i < ys.Length - 1 && ys[i + 1] - ys[i] > 1)
            {
                var nearLine = CalcLine(lines, ys[i] + 1, minX);
                var noLines = ys[i + 1] - ys[i] - 1;
                total += nearLine * noLines;
            }
        }

        return total;
    }

    private static long CalcLine(List<(int fromY, int fromX, int toY, int toX)> lines, int y, int minX)
    {
        var cross = lines
            .Where(l => l.fromY <= y && l.toY >= y)
            .OrderBy(l => l.fromX)
            .ThenBy(l => l.toX)
            .ToArray();
        var inside = false;
        var last = minX - 1;
        var lt = 0L;
        foreach (var line in cross)
        {
            if (inside)
            {
                lt += int.Max(line.fromX - last + 1, 0);
                last = int.Max(line.fromX + 1, line.fromX);
            }

            if (line.fromY == line.toY)
            {
                lt += int.Max(line.toX - int.Max(line.fromX, last) + 1, 0);
                last = int.Max(line.toX + 1, last);
            }
            else
            {
                if (line.fromY < y && line.toY >= y)
                {
                    inside = !inside;
                    if (inside)
                    {
                        last = int.Max(line.fromX, last);
                    }

                    if (line.fromX == last)
                    {
                        lt += 1;
                    }

                    last = int.Max(line.fromX + 1, last);
                }
                else
                {
                    if (line.fromX == last)
                    {
                        lt += 1;
                        last = line.fromX + 1;
                    }
                }
            }
        }

        return lt;
    }
}