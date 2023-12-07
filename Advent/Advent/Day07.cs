using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using CommandLine;

namespace Advent;

public class Day07
{
    public int Part1(string input)
    {
        var games = input.Split(Environment.NewLine);
        var results = games.Select(g => Parse(g))
            .OrderBy(r => r.game)
            .ToArray();

        var total = 0;
        for (var i = 0; i < results.Length; i++)

        {
            total += (i + 1) * results[i].bid;
        }

        return total;
    }

    public int Part2(string input)
    {
        var games = input.Split(Environment.NewLine);
        var results = games.Select(g => ParseJoker(g))
            .OrderBy(r => r.game)
            .ToArray();

        var total = 0;
        for (var i = 0; i < results.Length; i++)
        {
            total += (i + 1) * results[i].bid;
        }

        return total;
    }

    public (string game, int bid) Parse(string input)
    {
        var split = input.Split(' ');
        var bid = int.Parse(split[1]);

        split[0] = split[0]
            .Replace('A', 'E')
            .Replace('K', 'D')
            .Replace('Q', 'C')
            .Replace('J', 'B')
            .Replace('T', 'A');

        var type = GetType(split[0].ToCharArray());

        return (type + split[0], bid);
    }

    public char[] Options = "23456789ACDE".ToArray();

    public (string game, int bid) ParseJoker(string input)
    {
        var split = input.Split(' ');
        var bid = int.Parse(split[1]);

        split[0] = split[0]
            .Replace('A', 'E')
            .Replace('K', 'D')
            .Replace('Q', 'C')
            .Replace('J', '0')
            .Replace('T', 'A');

        var game = split[0].ToArray();

        var best = "";

        foreach (var c0 in (split[0][0] != '0' ? new[] { split[0][0] } : Options))
        {
            game[0] = c0;
            foreach (var c1 in (split[0][1] != '0' ? new[] { split[0][1] } : Options))
            {
                game[1] = c1;
                foreach (var c2 in (split[0][2] != '0' ? new[] { split[0][2] } : Options))
                {
                    game[2] = c2;
                    foreach (var c3 in (split[0][3] != '0' ? new[] { split[0][3] } : Options))
                    {
                        game[3] = c3;
                        foreach (var c4 in (split[0][4] != '0' ? new[] { split[0][4] } : Options))
                        {
                            game[4] = c4;
                            var result = GetType(game);
                            best = Best(result + split[0], best);
                        }

                    }

                }

            }
        }

        return (best, bid);
    }

    private string Best(string check, string best) =>
        string.Compare(check, best, StringComparison.Ordinal) > 0 ? check : best;

    public char GetType(char[] game)
    {
        var results = game.GroupBy(c => c)
            .Select(g => (g.Key, count: g.Count()))
            .ToArray();

        if (results.Length == 5) return 'A'; // Single
        if (results.Length == 4) return 'B'; // Pair
        if (results.Length == 3)
        {
            if (results[0].count == 3 || results[1].count == 3 || results[2].count == 3) return 'D'; // Three
            return 'C'; // Two pair
        }

        if (results.Length == 2)
        {
            if (results[0].count == 3 || results[1].count == 3) return 'E'; // Full
            return 'F'; // Four
        }

        return 'G'; // Five
    }
}

public class Day07Opt
{
    public int Part2Opt(string input)
    {
        var games = input.Split(Environment.NewLine);

        var results = games.Select(BestWithJoker)
            .OrderBy(g => g.sort)
            .ToArray();

        var total = 0;
        for (var i = 0; i < results.Length; i++)
        {
            total += (i + 1) * results[i].bid;
        }

        return total;
    }

    public (int sort, int bid) BestWithJoker(string game)
    {
        var (extract, sort, bid) = Extract(game);
        var jokers = extract[0];
        char type;
        if (jokers == 0)
        {
            type = GetType(extract);
        }
        else
        {
            var max = 0;
            var best = 0;
            for (var c = 1; c < extract.Length; c++)
                if (extract[c] > max)
                {
                    max = extract[c];
                    best = c;
                }

            if (best == 0)
            {
                type = 'G';
            }
            else
            {
                extract[best] += jokers;
                type = GetType(extract);
            }
        }

        sort += type << 20;

        return (sort, bid);
    }
    
    public (int[], int, int) Extract(string game)
    {
        var extract = new int[13];
        var sort = 0;
        for (var c = 0; c < 5; c++)
        {
            var ch = game[c] - '1';
            if (ch > 9)
            {
                ch = ch switch
                {
                    'T' - '1' => 9,
                    'J' - '1' => 0,
                    'Q' - '1' => 10,
                    'K' - '1' => 11,
                    'A' - '1' => 12
                };
            }
            sort += ch << ((4 - c) * 4);
            extract[ch]++;
        }

        var bid = 0;
        for (var c = 6; c < game.Length; c++)
            bid = bid * 10 + (game[c] - '0');

        return (extract, sort, bid);
    }
    
    public char GetType(int[] game)
    {
        bool three = false;
        bool pair = false;
        for (var i = 1; i < game.Length; i++)
        {
            if (game[i] == 5) return 'G'; // Five
            if (game[i] == 4) return 'F'; // Four
            if (game[i] == 3)
            {
                if (pair) return 'E'; // Full
                three = true;
            }

            if (game[i] == 2)
            {
                if (pair) return 'C'; // Two pair
                if (three) return 'E'; // Full
                pair = true;
            }
        }

        if (three) return 'D'; // Three
        if (pair) return 'B'; // Pair
        return 'A'; // Single
    }
}
