using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day05
{
    public long Part1(string input)
    {
        var (seeds, sections) = Parse(input);

        var min = long.MaxValue;
        
        foreach (var seed in seeds)
        {
            var current = seed;
            foreach (var section in sections)
            {
                foreach (var rule in section)
                {
                    if (current >= rule.source && current < rule.end)
                    {
                        current += rule.offset;
                        break;
                    }
                }
            }
            min = Math.Min(min, current);
        }

        return min;
    }

    public long Part2(string input)
    {
        var (seeds, sections) = Parse(input);

        var seedPair = new List<(long from, long to, long offset)>();
        for (var s = 0; s < seeds.Length - 1; s += 2)
        {
            seedPair.Add((seeds[s], seeds[s] + seeds[s + 1], 0L));
        }

        foreach (var section in sections)
        {
            foreach (var rule in section)
            {
                for (var s = 0; s < seedPair.Count; s++)
                {
                    var seed = seedPair[s];
                    if (seed.from < rule.end && seed.to > rule.source)
                    {
                        var from = seed.from;
                        var to = seed.to;
                        if (seed.from < rule.source)
                        {
                            seedPair.Add((seed.from, rule.source, seed.offset));
                            from = rule.source;
                        }

                        if (seed.to > rule.end)
                        {
                            seedPair.Add((rule.end, seed.to, seed.offset));
                            to = rule.end;
                        }

                        seedPair[s] = (from, to, rule.offset);
                    }
                }
            }

            seedPair = seedPair.Select(s =>
                    (s.from + s.offset, s.to + s.offset, 0L))
                .ToList();
        }

        return seedPair.Min(s => s.from);
    }

    private (long[] seeds, (long offset, long source, long end)[][] rules) Parse(string input)
    {
        var sections = input.Split(Environment.NewLine + Environment.NewLine);

        var seeds = sections[0].Split(':')[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();

        var rules = sections.Skip(1)
            .Select(section => section[(section.IndexOf(':') + 1)..]
                .Split(Environment.NewLine)
                .Where(l => l.Length > 3)
                .Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .Select(c => c.Select(long.Parse).ToArray())
                .Select(a => (offset: a[0] - a[1], source: a[1], end: a[1] + a[2]))
                .ToArray())
            .ToArray();

        return (seeds, rules);
    }

}