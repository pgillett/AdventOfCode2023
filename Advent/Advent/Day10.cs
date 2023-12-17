using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Advent;

public class Day10
{
    public int Part1(string input)
    {
        var rowLength = input.IndexOf(Environment.NewLine[0]) + Environment.NewLine.Length;

        var start = input.IndexOf('S');

        var dir = GetStartDirection(start, input, rowLength);
        
        var current = start;
        var steps = 0;
        while (true)
        {
            var move = Move(dir);
            current = current + move.dy * rowLength + move.dx;

            dir = ParsePipe(input[current]) ^ Change(dir); 

            steps++;
            if (current == start)
                break;
        }

        return steps / 2;
    }
    
    public int Part2(string input)
    {
        var rowLength = input.IndexOf(Environment.NewLine[0]) + Environment.NewLine.Length;

        var start = input.IndexOf('S');

        var dir = GetStartDirection(start, input, rowLength);

        var current = start;

        var map = new bool[input.Length];

        while (true)
        {
            map[current] = true;

            var move = Move(dir);
            current = current + move.dy * rowLength + move.dx;

            dir = ParsePipe(input[current]) ^ Change(dir);

            if (current == start)
                break;
        }

        var count = 0;
        var inOut = false;
        for (var i = 0; i < input.Length; i++)
            if (map[i])
            {
                if ((ParsePipe(input[i]) & Direction.North) != 0)
                    inOut = !inOut;
            }
            else
            {
                if (inOut)
                    count++;
            }

        return count;
    }
    
    private Direction GetStartDirection(int start, string map, int lineLength)
    {
        if (start > lineLength && (ParsePipe(map[start - lineLength]) & Direction.South) != 0)
            return Direction.North;
        if (start > 0 && (ParsePipe(map[start - 1]) & Direction.East) != 0)
            return Direction.West;
        if (start < map.Length - 1 && (ParsePipe(map[start + 1]) & Direction.West) != 0)
            return Direction.East;
        return Direction.South;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Direction Change(Direction direction) =>
        direction switch
        {
            Direction.North => Direction.South,
            Direction.South => Direction.North,
            Direction.East => Direction.West,
            Direction.West => Direction.East,
            _ => throw new Exception($"{direction}")
        };
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public (int dy, int dx) Move(Direction direction) =>
        direction switch
        {
            Direction.North => (-1, 0),
            Direction.South => (1, 0),
            Direction.East => (0, 1),
            Direction.West => (0, -1),
            _ => throw new Exception($"{direction}")
        };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Direction[] Parse(string input)
    {
        return input.Select(ParsePipe).ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Direction ParsePipe(char input) => input switch
        {
            '|' => Direction.North | Direction.South,
            '-' => Direction.East | Direction.West,
            'L' => Direction.North | Direction.East,
            'J' => Direction.North | Direction.West,
            '7' => Direction.South | Direction.West,
            'F' => Direction.South | Direction.East,
            _ => 0
        };

    [Flags]
    public enum Direction
    {
        North = 0b00001,
        South = 0b00010,
        East  = 0b00100,
        West  = 0b01000
    }
    
}