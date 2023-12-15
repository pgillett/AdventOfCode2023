using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Advent;

public class Day14
{
    public int Part1(string input)
    {
        var map = input.Split(Environment.NewLine)
            .Select(s => s.ToCharArray()).ToArray();

        var load = 0;
        for (var c = 0; c < map[0].Length; c++)
        {
            var move = 0;
            for (var r = 0; r < map.Length; r++)
            {
                var m = map[r][c];
                if (m == 'O')
                {
                    load += map.Length - move;
                    move++;
                }
                else if (m == '#')
                {
                    move = r + 1;
                }
            }
        }
        return load;
    }

    public int Part2(string input)
    {
        var map = input.Split(Environment.NewLine)
            .Select(s => s.ToCharArray().Select(i => (int)i).ToArray()).ToArray();

        var hashes = new Dictionary<int, (int step, int load)>();

        for (var i = 0; i < 1000; i++)
        {
            North(map);
            West(map);
            South(map);
            East(map);

            var loadHash = LoadAndHash(map);

            if (hashes.TryGetValue(loadHash.hash, out var stepLoad))
            {
                var cycles = 1000000000 - 1;
                var diff = i - stepLoad.step;
                var full = (cycles - stepLoad.step) / diff;
                var end = stepLoad.step + full * diff;
                var offset = cycles - end;
                var copy = stepLoad.step + offset;
                
                var value = hashes.Values.Single(v => v.step == copy);
        
                return value.load;
            }

            hashes[loadHash.hash] = (i, loadHash.load);
        }

        return 0;
    }
    
    public void North(int[][] map)
    {
        for (var c = 0; c < map[0].Length; c++)
        {
            var move = 0;
            for (var r = 0; r < map.Length; r++)
            {
                var m = map[r][c];
                if (m == 'O')
                {
                    map[r][c] = '.';
                    map[move][c] = 'O';
                    move++;
                }
                else if (m == '#')
                {
                    move = r + 1;
                }
            }
        }
    }
    
    public void South(int[][] map)
    {
        for (var c = 0; c < map[0].Length; c++)
        {
            var move = map.Length - 1;
            for (var r = map.Length - 1; r >= 0; r--)
            {
                var m = map[r][c];
                if (m == 'O')
                {
                    map[r][c] = '.';
                    map[move][c] = 'O';
                    move--;
                }
                else if (m == '#')
                {
                    move = r - 1;
                }
            }
        }
    }
    
    public void West(int[][] map)
    {
        for (var r = 0; r < map.Length; r++)
        {
            var move = 0;
            for (var c = 0; c < map[0].Length; c++)
            {
                var m = map[r][c];
                if (m == 'O')
                {
                    map[r][c] = '.';
                    map[r][move] = 'O';
                    move++;
                }
                else if (m == '#')
                {
                    move = c + 1;
                }
            }
        }
    }
    
    public void East(int[][] map)
    {
        for (var r = 0; r < map.Length; r++)
        {
            var move = map[0].Length - 1;
            for (var c = map[0].Length - 1; c >= 0; c--)
            {
                var m = map[r][c];
                if (m == 'O')
                {
                    map[r][c] = '.';
                    map[r][move] = 'O';
                    move--;
                }
                else if (m == '#')
                {
                    move = c - 1;
                }
            }
        }
    }
    
    public (int load, int hash) LoadAndHash(int[][] map)
    {
        var load = 0;
        var hash = 0;
        for (var c = 0; c < map[0].Length; c++)
        {
            for (var r = 0; r < map.Length; r++)
            {
                var m = map[r][c];
                hash = hash * 23 + m;//.GetHashCode();
                if (m == 'O')
                {
                    load += map.Length - r;
                }
            }
        }

        return (load, hash);
    }
    
    public int Part2Speed(string input)
    {
        var map = input.Split(Environment.NewLine)
            .Select(s => s.ToCharArray().Select(i => (int)i).ToArray()).ToArray();

        var load = 0L;

        var first = 0;
        var second = 0;
        for (var i = 0; i < 10000; i++)
        {
            North(map);
            West(map);
            South(map);
            East(map);
        }

        return 0;
    }

}