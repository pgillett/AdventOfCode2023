using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Advent;

public class Day16
{
    public int Part1(string input)
    {
        var map = input.Split(Environment.NewLine)
            .Select(l => l.Select(Parse).ToArray()).ToArray();

        return CalcSeen(map, (0, -1, Direction.Right));
    }

    public int Part2(string input)
    {
        var map = input.Split(Environment.NewLine)
            .Select(l => l.Select(Parse).ToArray()).ToArray();

        var max = 0;
        for (var c = 0; c < map[0].Length; c++)
        {
            max = Math.Max(max, CalcSeen(map, (-1, c, Direction.Down)));
            max = Math.Max(max, CalcSeen(map, (map.Length, c, Direction.Up)));
        }

        for (var r = 0; r < map[0].Length; r++)
        {
            max = Math.Max(max, CalcSeen(map, (r, -1, Direction.Right)));
            max = Math.Max(max, CalcSeen(map, (r, map[0].Length, Direction.Left)));
        }

        return max;
    }

    public int CalcSeen(Mirror[][] map, (int y, int x, Direction direction) start)
    {
        foreach (var row in map)
        {
            for (var c = 0; c < row.Length; c++)
                row[c] &= Mirror.Direction;
        }

        var queue = new Queue<(int y, int x, Direction direction)>();

        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var beam = queue.Dequeue();

            var move = Move(beam.direction);
            var x = beam.x + move.dx;
            var y = beam.y + move.dy;

            if (x < 0 || y < 0 || x == map[0].Length || y == map.Length)
                continue;

            var directionAsMirror = (Mirror)((int)beam.direction << 8);
            if((map[y][x] & directionAsMirror) != 0)
                continue;

            map[y][x] |= directionAsMirror;

            switch ((beam.direction, map[y][x] & Mirror.Direction))
            {
                case (Direction.Right, Mirror.DownRight):
                case (Direction.Left, Mirror.UpRight):
                    queue.Enqueue((y, x, Direction.Down));
                    break;
                case (Direction.Right, Mirror.UpRight):
                case (Direction.Left, Mirror.DownRight):
                    queue.Enqueue((y, x, Direction.Up));
                    break;
                case (Direction.Right, Mirror.Vertical):
                case (Direction.Left, Mirror.Vertical):
                    queue.Enqueue((y, x, Direction.Up));
                    queue.Enqueue((y, x, Direction.Down));
                    break;
                case (Direction.Up, Mirror.DownRight):
                case (Direction.Down, Mirror.UpRight):
                    queue.Enqueue((y, x, Direction.Left));
                    break;
                case (Direction.Up, Mirror.UpRight):
                case (Direction.Down, Mirror.DownRight):
                    queue.Enqueue((y, x, Direction.Right));
                    break;
                case (Direction.Up, Mirror.Horizontal):
                case (Direction.Down, Mirror.Horizontal):
                    queue.Enqueue((y, x, Direction.Left));
                    queue.Enqueue((y, x, Direction.Right));
                    break;
                default:
                    queue.Enqueue((y, x, beam.direction));
                    break;
            }
        }

        return map.Sum(row => row.Count(m => (m & Mirror.Seen) != 0));
    }
    
    [Flags]
    public enum Mirror
    {
        None = 0,
        Horizontal = 1,
        Vertical = 2,
        DownRight = 3,
        UpRight = 4,
        Direction = 7,
        Seen = 15 << 8
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Mirror Parse(char c) =>
        c switch
        {
            '.' => Mirror.None,
            '|' => Mirror.Vertical,
            '-' => Mirror.Horizontal,
            '\\' => Mirror.DownRight,
            '/' => Mirror.UpRight,
            _ => throw new Exception($"Mirror {c}")
        };

    public enum Direction
    {
        Left = 1,
        Right = 2,
        Up = 4,
        Down = 8
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public (int dy, int dx) Move(Direction direction) =>
        direction switch
        {
            Direction.Left => (0, -1),
            Direction.Right => (0, 1),
            Direction.Up => (-1, 0),
            Direction.Down => (1, 0),
            _ => throw new Exception($"Direction {direction}")
        };
}