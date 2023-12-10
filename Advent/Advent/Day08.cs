using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day08
{
    public int Part1(string input)
    {
        var split = input.Split(Environment.NewLine + Environment.NewLine);

        var instruct = split[0];

        var moves = split[1].Split(Environment.NewLine)
            .ToDictionary(m => m.Substring(0, 3),
                m => (m.Substring(7, 3), m.Substring(12, 3)));
        
        var pos = "AAA";
        var l = 0;
        while (true)
        {
            var dir = instruct[l % instruct.Length];
            pos = dir == 'R' ? moves[pos].Item2 : moves[pos].Item1;
            if (pos == "ZZZ")
                break;
            l++;
        }
        return l+1;
    }

    public long Part2(string input)
    {
        var split = input.Split(Environment.NewLine + Environment.NewLine);

        var instruct = split[0];

        var moves = split[1].Split(Environment.NewLine)
            .ToDictionary(m => m.Substring(0, 3),
                m => (m.Substring(7, 3), m.Substring(12, 3)));

        var pos = moves.Keys.Where(k => k[2] == 'A').
            ToArray();
        
        var loop = new int [pos.Length];

        Debug.WriteLine($"{instruct.Length}");

        for (var p = 0; p < pos.Length; p++)
        {
            var l = 0;
            var c = pos[p];
            
            Debug.WriteLine($"-- {p} --");

            while (true)
            {
                var i = l % instruct.Length;

                if (c[2] == 'Z' && l % instruct.Length == 0)
                {
                    break;
                }

                var dir = instruct[i];
                c = dir == 'R' ? moves[c].Item2 : moves[c].Item1;
                l++;

                if (l > 100000) break;
            }

            loop[p] = l;
        }

       return LowestCommon(loop);
    }
    
    public long Part2a(string input)
    {
        var split = input.Split(Environment.NewLine + Environment.NewLine);

        var instruct = split[0];

        var moves = split[1].Split(Environment.NewLine)
            .ToDictionary(m => m.Substring(0, 3),
                m => (m.Substring(7, 3), m.Substring(12, 3)));

        var swap = moves.Keys.Select((k, i) => (k, i)).ToDictionary(ki => ki.k, ki => ki.i);

        var moves2 = new uint[moves.Count];
        foreach (var m in moves)
        {
            var index = swap[m.Key];
            var left = (uint)swap[m.Value.Item1];
            var right = (uint)swap[m.Value.Item2];
            var move = (((uint)index) << 22) | (left << 12) | (right << 2) |
                       (m.Key[2] == 'A' ? (uint)2 : 0) | (m.Key[2] == 'Z' ? (uint)1 : 0);
            moves2[index] = move;
        }

        var pos = moves2.Where(m => (m & 2) == 2).ToArray();
        
        var loop = new int [pos.Length];
        for (var p = 0; p < pos.Length; p++)
        {
            var l = 0;
            var c = pos[p];

            var iPos = 0;
            
            Debug.WriteLine($"-- {p} --");

            while (true)
            {
                var dir = instruct[iPos];
                c = moves2[dir == 'R' ? (c >> 2) & 0b1111111111 : (c >> 12) & 0b1111111111];
                iPos++;
                if (iPos == instruct.Length)
                {
                    iPos = 0;
                    l += instruct.Length;
                    if ((c & 1) == 1)
                    {
                        break;
                    }
                }
            }

            loop[p] = l;
        }

        return LowestCommon(loop);
    }

    public long LowestCommon(int[] values)
    {
        Debug.WriteLine(string.Join(' ', values));
        
        var current = (long)values[0];
        for (var p = 1; p < values.Length; p++)
        {
            var gcf = 1;
            var div = 2;
            while (div <= current && div <= values[p])
            {
                if (current % div == 0 && values[p] % div == 0)
                {
                    current /= div;
                    values[p] /= div;
                    gcf *= div;
                }
                else
                {
                    div = div == 2 ? 3 : div + 2;
                }
            }

            current *= values[p] * gcf;
        }

        Debug.WriteLine($"Smallest {current}");
        return current;
        
    }
}