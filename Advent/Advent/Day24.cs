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
                var s = l.Split(new[] { '@', ',' }, StringSplitOptions.TrimEntries).Select(long.Parse).ToArray();
                return (pos: new [] { s[0], s[1], s[2] }, vel: new [] { s[3], s[4], s[5] });
            }).ToArray();

        for (var axis = 0; axis < 3; axis++)
        {
            // positive

            {
                var maxX = 0L;

                var set1 = hailstones.Where(h => h.vel[axis] < 0)
                    .ToArray();
                if (set1.Length > 0)
                    maxX = set1.Min(h => h.pos[axis] + h.vel[axis]);

                var minV = 1L;
                var set = hailstones.Where(h => h.vel[axis] > 0 && h.pos[axis] > maxX)
                    .ToArray();
                if (set.Length > 0)
                    minV = set.Max(h => h.vel[axis]) + 1;

                maxX = maxX - minV;

                Debug.WriteLine($"Axis {axis}+ : P <= {maxX} and V >= {minV}");

                if (hailstones.All(h => Intersect(minV, maxX, h.vel[axis], h.pos[axis])))
                {
                    Debug.WriteLine("Intersects all");
                }

                var v = minV;
                while (minV < 100)
                {
                    var p = maxX;
                    var found = false;
                    while (true)
                    {
                        var end = false;
                        var ok = true;
                        foreach (var h in hailstones)
                        {
                            if (p > h.pos[axis] && minV > h.vel[axis])
                            {
                                end = true;
                                break;
                            }

                            if (!Intersect(minV, p, h.vel[axis], h.pos[axis]))
                            {
                                p -= 1;
                                ok = false;
                                break;
                            }
                        }
                        if (p < -100)
                        {
                            end = true;
                            break;
                        }

                        if (end)
                            break;
                        if (ok)
                        {
                            Debug.WriteLine($"Axis {axis}: pos {p} vel: {minV}");
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        break;
                    minV++;
                }
            }

            // negative

            {
                var minX = 0L;
                var set1 = hailstones.Where(h => h.vel[axis] > 0)
                    .ToArray();
                if (set1.Length > 0)
                    minX = set1.Max(h => h.pos[axis] + h.vel[axis]);

                var minV = -1L;
                var set = hailstones.Where(h => h.vel[axis] < 0 && h.pos[axis] < minX)
                    .ToArray();
                if (set.Length > 0)
                    minV = set.Min(h => h.vel[axis]) - 1;

                minX = minX - minV;

                Debug.WriteLine($"Axis {axis}- : P >= {minX} and V >= {minV}");

                if (hailstones.All(h => Intersect(minV, minX, h.vel[axis], h.pos[axis])))
                {
                    Debug.WriteLine("Intersects all");
                }

                while (minV > -100)
                {
                    var p = minX;
                    var found = false;
                    while (true)
                    {
                        var end = false;
                        var ok = true;
                        foreach (var h in hailstones)
                        {
                            if (p < h.pos[axis] && minV < h.vel[axis])
                            {
                                end = true;
                                break;
                            }

                            if (!Intersect(minV, p, h.vel[axis], h.pos[axis]))
                            {
                                p += 1;
                                ok = false;
                                break;
                            }
                        }
                        if (p > 100)
                        {
                            end = true;
                            break;
                        }

                        if (end)
                            break;
                        if (ok)
                        {
                            Debug.WriteLine($"Axis {axis}: pos {p} vel: {minV}");
                            found = true;
                            break;
                        }

                    }
                    minV--;
                    if (found)
                        break;
                }
            }
        }

        return 0;

        for (var axis = 0; axis < 3; axis++)
        {
            for (var v = -1; v > -5; v--)
            {
                var p = 0;
                var end = false;
                while (true)
                {
                    var ok = true;
                    foreach (var h in hailstones)
                    {
                        if (p < h.pos[axis] && v < h.vel[axis])
                        {
                            end = true;
                            break;
                        }

                        if (!Intersect(v, p, h.pos[axis], h.vel[axis]))
                        {
                            p -= 1;
                            ok = false;
                            break;
                        }

                        if (p < -100)
                        {
                            end = true;
                            break;
                        }
                    }

                    if (end)
                        break;
                    if (ok)
                    {
                        Debug.WriteLine($"Axis {axis}: pos {p} vel: {v}");
                    }
                }
            }
            for (var v = 1; v < 5; v++)
            {
                var p = 0;
                var end = false;
                while (true)
                {
                    var ok = true;
                    foreach (var h in hailstones)
                    {
                        if (p > h.pos[axis] && v > h.vel[axis])
                        {
                            end = true;
                            break;
                        }

                        if (!Intersect(v, p, h.pos[axis], h.vel[axis]))
                        {
                            p += 1;
                            ok = false;
                            break;
                        }

                        if (p > 100)
                        {
                            end = true;
                            break;
                        }
                    }

                    if (end)
                        break;
                    if (ok)
                    {
                        Debug.WriteLine($"Axis {axis}: pos {p} vel: {v}");
                    }
                }
            }

        }

        return 0;
        // var maxTime = 100;
        // var positions = hailstones.Select(_ => new (double x, double y, double z)[maxTime+1]).ToArray();
        //
        // for (var t = 1; t < maxTime; t++)
        // {
        //     for (var f = 0; f < hailstones.Length; f++)
        //     {
        //         positions[f][t-1] = (hailstones[f].px + hailstones[f].vx * t,
        //             hailstones[f].py + hailstones[f].vy * t,
        //             hailstones[f].pz + hailstones[f].vz * t);
        //     }
        // }

        // var counts = new Dictionary<(double, double, double), List<(int first, int second, int time)>>();
        //
        // for (var t = 1; t < maxTime-2; t++)
        // {
        //     for (var f = 0; f < hailstones.Length; f++)
        //     {
        //         for (var s = 0; s < hailstones.Length; s++)
        //         {
        //             if (s == f) continue;
        //             var dx = positions[s][t+1].x - positions[f][t].x;
        //             var dy = positions[s][t+1].y - positions[f][t].y;
        //             var dz = positions[s][t+1].z - positions[f][t].z;
        //             if (!counts.ContainsKey((dx, dy, dz)))
        //             {
        //                 counts[(dx, dy, dz)]=new List<(int first, int second, int time)>();
        //             }
        //             counts[(dx, dy, dz)].Add((f,s, t));
        //         }
        //     }
        //
        //   //  var max = counts.Values.Max();
        // }
        //
        // var maybe = counts.Where(k => k.Value.Count > 1).ToList();
        //
        // return hailstones.Length;
    }

    public bool Intersect(long v1, long s1, long v2, long s2)
    {
        if (v1 == v2) return (s2 == s1);
        return (s2 - s1) % (v1 - v2) == 0;
    }
}