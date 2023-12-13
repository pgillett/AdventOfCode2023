using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day13
{
    public int Part1(string input)
    {
        var patterns = input.Split(Environment.NewLine + Environment.NewLine)
            .Select(p => p.Split(Environment.NewLine)).ToArray();

        var total = 0;
        
        foreach (var pattern in patterns)
        {
            var d = "V";
            var good = new HashSet<int>();
            for (var x = 0; x < pattern[0].Length-1; x++)
                good.Add(x);
            for(var y = 0;y<pattern.Length;y++)
            foreach(var x in good)
            {
                for (var dx = 0; dx <= Math.Min(pattern[0].Length-x-2,x); dx++)
                {
                    if (pattern[y][x - dx] != pattern[y][x + 1 + dx])
                    {
                        good.Remove(x);
                        break;
                    }
                }
            }

            
            if (good.Count == 0)
            {
                d = "H";
                for (var y = 0; y < pattern.Length-1; y++)
                    good.Add(y);
                for(var x = 0;x<pattern[0].Length;x++)
                    foreach(var y in good)
                    {
                        for (var dy = 0; dy <= Math.Min(pattern.Length-y-2,y); dy++)
                        {
                            if (pattern[y - dy][x] != pattern[y + 1 + dy][x])
                            {
                                good.Remove(y);
                                break;
                            }
                        }
                    }
            }

            total += d == "V" ? good.First() + 1 : 100 * (good.First() + 1);
        }
        return total;
    }

    public int Part2(string input)
    {
        var patterns = input.Split(Environment.NewLine + Environment.NewLine)
            .Select(p => p.Split(Environment.NewLine)).ToArray();

        var total = 0;

        foreach (var pattern in patterns)
        {
            var vertCount = new Dictionary<int, int>();
            for (var x = 0; x < pattern[0].Length - 1; x++)
                vertCount[x] = 0;
            for (var y = 0; y < pattern.Length; y++)
            for (var x = 0; x < pattern[0].Length - 1; x++)
            {
                var ok = true;
                for (var dx = 0; dx <= Math.Min(pattern[0].Length - x - 2, x); dx++)
                {
                    if (pattern[y][x - dx] != pattern[y][x + 1 + dx])
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                    vertCount[x]++;
            }
            
            var horizCount = new Dictionary<int, int>();
            for (var y = 0; y < pattern.Length - 1; y++)
                horizCount[y] = 0;
            for (var x = 0; x < pattern[0].Length; x++)
            {
                for (var y = 0; y < pattern.Length - 1; y++)
                {
                    var ok = true;
                    for (var dy = 0; dy <= Math.Min(pattern.Length - y - 2, y); dy++)
                    {
                        if (pattern[y - dy][x] != pattern[y + 1 + dy][x])
                        {
                            ok = false;
                            break;
                        }
                    }
                    
                    if (ok)
                        horizCount[y]++;
                }
            }

            var h = 0;
            var v = 0;
            if (horizCount.Count(kvp => kvp.Value == pattern[0].Length - 1) == 1)
            {
                h = horizCount.Single(kvp => kvp.Value == pattern[0].Length - 1).Key + 1; 
            }
            
            if (vertCount.Count(kvp => kvp.Value == pattern.Length - 1) == 1)
            {
                v = vertCount.Single(kvp => kvp.Value == pattern.Length - 1).Key + 1; 
            }

            total += v + 100 * h;
        }

        return total;
    }
}