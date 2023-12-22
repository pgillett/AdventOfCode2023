using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent;

public class Day21
{
    public int Part1(string input, int steps)
    {
        var map = input.Split(Environment.NewLine);

        var lowest = new List<int[]>();
        var start = (y: 0, x: 0);
        for (var l = 0; l < map.Length; l++)
        {
            lowest.Add(new int[map[0].Length]);
            Array.Fill(lowest[l], int.MaxValue);
            var i = map[l].IndexOf('S');
            if (i >= 0)
                start = (l, i);
        }

        var queue = new Queue<(int y, int x, int step)>();

        queue.Enqueue((start.y, start.x, 0));

        while (queue.Count > 0)
        {
            var pos = queue.Dequeue();
            if (map[pos.y][pos.x] == '#') continue;

            if (pos.step < lowest[pos.y][pos.x])
            {
                lowest[pos.y][pos.x] = pos.step;
                if (pos.step == steps) continue;
                if (pos.x > 0) queue.Enqueue((pos.y, pos.x - 1, pos.step + 1));
                if (pos.y > 0) queue.Enqueue((pos.y - 1, pos.x, pos.step + 1));
                if (pos.x < map[0].Length - 1) queue.Enqueue((pos.y, pos.x + 1, pos.step + 1));
                if (pos.y < map.Length - 1) queue.Enqueue((pos.y + 1, pos.x, pos.step + 1));
            }
        }

        return lowest.Sum(l => l.Count(x => (x & 1) == 0));
    }

    public int Part2(string input)
    {
        return 0;
    }
}