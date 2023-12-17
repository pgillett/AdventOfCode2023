using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day17
{
    public int Part1(string input)
    {
        var map = input.Split(Environment.NewLine)
            .Select(l => l.Select(c => c - '0').ToArray()).ToArray();

        var lossMap = map.Select(r =>
            r.Select(c => new Dictionary<(Direction, int), int>())
                .ToArray()).ToArray();

        var queue = new Queue<(int y, int x, Direction direction, int steps, int loss)>();

        queue.Enqueue((0, 0, Direction.Left, 0, -map[0][0]));

        while (queue.Count > 0)
        {
            var pos = queue.Dequeue();

            var loss = pos.loss + map[pos.y][pos.x];

            var mapLookup = lossMap[pos.y][pos.x];

            if (!mapLookup.ContainsKey((pos.direction, pos.steps)) ||
                (loss < mapLookup[(pos.direction, pos.steps)]))
            {
                mapLookup[(pos.direction, pos.steps)] = loss;
                var steps = pos.steps + 1;
                if (pos.x > 0 && pos.direction != Direction.Right)
                {
                    if (pos.direction != Direction.Left) steps = 0;
                    if (steps < 3)
                        queue.Enqueue((pos.y, pos.x - 1, Direction.Left, steps, loss));
                }
                steps = pos.steps + 1;
                if (pos.y > 0 && pos.direction != Direction.Down)
                {
                    if (pos.direction != Direction.Up) steps = 0;
                    if (steps < 3)
                        queue.Enqueue((pos.y - 1, pos.x, Direction.Up, steps, loss));
                }
                steps = pos.steps + 1;
                if (pos.x < map[0].Length - 1 && pos.direction != Direction.Left)
                {
                    if (pos.direction != Direction.Right) steps = 0;
                    if (steps < 3)
                        queue.Enqueue((pos.y, pos.x + 1, Direction.Right, steps, loss));
                }
                steps = pos.steps + 1;
                if (pos.y < map.Length - 1 && pos.direction != Direction.Up)
                {
                    if (pos.direction != Direction.Down) steps = 0;
                    if (steps < 3)
                        queue.Enqueue((pos.y + 1, pos.x, Direction.Down, steps, loss));
                }
            }
        }

        // foreach (var row in lossMap)
        // {
        //     Debug.WriteLine("");
        //     foreach (var col in row)
        //     {
        //         var val = col.Values.Min();
        //         if (val < int.MaxValue)
        //         {
        //             Debug.Write(string.Format("{0,3}",val));
        //         }
        //     }
        // }
        
        return lossMap[map.Length-1][map[0].Length-1].Values.Min();
    }

    public enum Direction
    {
        Up, Down, Left, Right, Undefined
    }

    public int Part2(string input)
    {
                var map = input.Split(Environment.NewLine)
            .Select(l => l.Select(c => c - '0').ToArray()).ToArray();

        var lossMap = map.Select(r =>
            r.Select(c => new Dictionary<(Direction, int), int>())
                .ToArray()).ToArray();

        var queue = new Queue<(int y, int x, Direction direction, int steps, int loss)>();

        queue.Enqueue((0, 0, Direction.Undefined, 5, -map[0][0]));

        while (queue.Count > 0)
        {
            var pos = queue.Dequeue();

            var loss = pos.loss + map[pos.y][pos.x];

            var mapLookup = lossMap[pos.y][pos.x];

            if (!mapLookup.ContainsKey((pos.direction, pos.steps)) ||
                (loss < mapLookup[(pos.direction, pos.steps)]))
            {
                if (pos.y == map.Length - 1 && pos.x == map[0].Length - 1 && pos.steps < 3)
                    continue;
                
                mapLookup[(pos.direction, pos.steps)] = loss;
                var steps = pos.steps + 1;
                if (pos.x > 0 && pos.direction != Direction.Right
                              && (pos.direction == Direction.Left || steps > 3))
                {
                    if (pos.direction != Direction.Left) steps = 0;
                    if (steps < 10)
                        queue.Enqueue((pos.y, pos.x - 1, Direction.Left, steps, loss));
                }
                steps = pos.steps + 1;
                if (pos.y > 0 && pos.direction != Direction.Down
                              && (pos.direction == Direction.Up || steps > 3))
                {
                    if (pos.direction != Direction.Up) steps = 0;
                    if (steps < 10)
                        queue.Enqueue((pos.y - 1, pos.x, Direction.Up, steps, loss));
                }
                steps = pos.steps + 1;
                if (pos.x < map[0].Length - 1 && pos.direction != Direction.Left
                                              && (pos.direction == Direction.Right || steps > 3))
                {
                    if (pos.direction != Direction.Right) steps = 0;
                    if (steps < 10)
                        queue.Enqueue((pos.y, pos.x + 1, Direction.Right, steps, loss));
                }
                steps = pos.steps + 1;
                if (pos.y < map.Length - 1 && pos.direction != Direction.Up
                                           && (pos.direction == Direction.Down || steps > 3))
                {
                    if (pos.direction != Direction.Down) steps = 0;
                    if (steps < 10)
                        queue.Enqueue((pos.y + 1, pos.x, Direction.Down, steps, loss));
                }
            }
        }

        // foreach (var row in lossMap)
        // {
        //     Debug.WriteLine("");
        //     foreach (var col in row)
        //     {
        //         var val = col.Values.Min();
        //         if (val < int.MaxValue)
        //         {
        //             Debug.Write(string.Format("{0,3}",val));
        //         }
        //     }
        // }
        
        return lossMap[map.Length-1][map[0].Length-1].Values.Min();
    }
}