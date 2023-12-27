using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day24
{
    public int Part1(string input, bool large)
    {
        var min = large ? 200000000000000 : 7;
        var max = large ? 400000000000000 : 27;
        
        var hailstones = input.Split(Environment.NewLine)
            .Select(l =>
            {
                var s = l.Split(new[] { '@', ',' }, StringSplitOptions.TrimEntries).Select(double.Parse).ToArray();
                return (px: s[0], py: s[1], pz: s[2], vx: s[3], vy: s[4], vz: s[5]);
            }).ToArray();

        var count = 0;
        for (var f = 0; f < hailstones.Length - 1; f++)
        {
            for (var s = f + 1; s < hailstones.Length; s++)
            {
                var gradientF = hailstones[f].vy / hailstones[f].vx;
                var gradientS = hailstones[s].vy / hailstones[s].vx;
                var xInt = (gradientF * hailstones[f].px - gradientS * hailstones[s].px + hailstones[s].py - hailstones[f].py) / (gradientF - gradientS);

                var yInt = (xInt - hailstones[f].px) * gradientF + hailstones[f].py;

                if (xInt > min && xInt <= max && yInt > min && yInt <= max)
                {
                    if (Math.Sign(hailstones[f].vx) == Math.Sign(xInt - hailstones[f].px) && Math.Sign(hailstones[s].vx) == Math.Sign(xInt - hailstones[s].px))
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    public int Part2(string input)
    {
        var hailstones = input.Split(Environment.NewLine)
            .Select(l =>
            {
                var s = l.Split(new[] { '@', ',' }, StringSplitOptions.TrimEntries).Select(double.Parse).ToArray();
                return (px: s[0], py: s[1], pz: s[2], vx: s[3], vy: s[4], vz: s[5]);
            }).ToArray();

        var maxTime = 100;
        var positions = hailstones.Select(_ => new (double x, double y, double z)[maxTime+1]).ToArray();

        for (var t = 1; t < maxTime; t++)
        {
            for (var f = 0; f < hailstones.Length; f++)
            {
                positions[f][t-1] = (hailstones[f].px + hailstones[f].vx * t,
                    hailstones[f].py + hailstones[f].vy * t,
                    hailstones[f].pz + hailstones[f].vz * t);
            }
        }

        var counts = new Dictionary<(double, double, double), List<(int first, int second, int time)>>();
        
        for (var t = 1; t < maxTime-2; t++)
        {
            for (var f = 0; f < hailstones.Length; f++)
            {
                for (var s = 0; s < hailstones.Length; s++)
                {
                    if (s == f) continue;
                    var dx = positions[s][t+1].x - positions[f][t].x;
                    var dy = positions[s][t+1].y - positions[f][t].y;
                    var dz = positions[s][t+1].z - positions[f][t].z;
                    if (!counts.ContainsKey((dx, dy, dz)))
                    {
                        counts[(dx, dy, dz)]=new List<(int first, int second, int time)>();
                    }
                    counts[(dx, dy, dz)].Add((f,s, t));
                }
            }

          //  var max = counts.Values.Max();
        }

        var maybe = counts.Where(k => k.Value.Count > 1).ToList();

        return hailstones.Length;
    }
}