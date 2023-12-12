using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day12
{
    public int Part1(string input)
    {
        var cards = input.Split(Environment.NewLine)
            .Select(Parse).ToArray();

        var total = 0;
        foreach (var card in cards)
        {
            total+=Card(card);
        }
        return total;
    }

    public (string springs, int[] lengths) Parse(string input)
    {
        var s = input.Split(' ');
        var springs = s[0];
        var lengths = s[1].Split(',').Select(int.Parse).ToArray();
        return (springs, lengths);
    }

    public int Card((string, int[]) card)
    {
        var lengths = card.Item2;
        var springs = card.Item1;
        
        var minLength = lengths.Sum() + lengths.Length - 1;

        var queue = new Queue<int[]>();

        var left = new int[springs.Length];
        var totals = new int[lengths.Length];
        var min = new int[springs.Length];
        var used = new int[lengths.Length];
        var ends = new int[lengths.Length];
        {
            var totalFixed = springs.Count(c => c == '#');
            {
                var total = 0;
                for (var c = 0; c < springs.Length; c++)
                {
                    if (springs[c] == '#')
                        total++;
                    min[c] = total;
                    left[c] = totalFixed - total;
                }

                total = lengths.Sum();
                var use = 0;
                for (var t = 0; t < lengths.Length; t++)
                {
                    used[t] = use;
                    use += lengths[t];
                    totals[t] = total;
                    total -= lengths[t];
                }

                total = springs.Length;
                for (var t = lengths.Length - 1; t >= 0; t--)
                {
                    total -= lengths[t];
                    ends[t] = total;
                    total -= 1;
                }
            }
        }

        var could = new int[springs.Length+1];
        could[0] = 0;
        for (var i = 1; i < springs.Length+1; i++)
            could[i] = could[i - 1] + (springs[i-1] != '.' ? 1 : 0);

        var currentPos = new int[0];

        queue.Enqueue(currentPos);
        
        Debug.WriteLine("");
        Debug.WriteLine($"{springs} {string.Join(',',lengths)}");
        Debug.WriteLine("----------------");

        var count = 0;

        var lastCurrent = 0;
        
        while (queue.Count > 0)
        {
            var next = 0;
            var current = 0;

            currentPos = queue.Dequeue();
            
            if (currentPos.Length > 0)
            {
                next = currentPos[^1] + lengths[currentPos.Length - 1] + 1;
                current = currentPos.Length;
            }

            if (current != lastCurrent)
                lastCurrent = current;

            var end = ends[current];
            
            {
                for (var p = next; p <= end; p++)
                {
                    if (p > 0 && springs[p - 1] == '#')
                        break;
                    
                    if(springs[p] == '.')
                        continue;
                    
                    var match = true;

                    {
                        var after = p + lengths[current];
                        if (after < springs.Length && springs[after] == '#')
                            match = false;
                    }

                    {
                        if (totals[current] <= (left[p]-1))
                            match = false;
                        if (p > 0 && min[p - 1] > used[current])
                            continue;
//                            match = false;
                    }

                    if (match)
                    {
                        match = could[p + lengths[current]] - could[p] == lengths[current];
                    }
                    

                    if (match)
                    {
                        if (current == lengths.Length - 1)
                        {
                            var all = true;
                            for (var check = p+lengths[current]; check < springs.Length; check++)
                            {
                                if (springs[check] == '#')
                                {
                                    all = false;
                                    break;
                                }
                            }

                            if (all)
                            {
                                var chars = new char[springs.Length];
                                Array.Fill(chars, '.');
                                for (var s = 0; s < lengths.Length; s++)
                                {
                                    var from = s < lengths.Length - 1 ? currentPos[s] : p;
                                    for (var f = 0; f < lengths[s]; f++)
                                        chars[from + f] = '#';
                                }

     //                           Console.WriteLine($"{new string(chars)}");
                                count++;
                            }
                        }
                        else
                        {
                            var newPos = new int[current + 1];
                            for (var c = 0; c < current; c++)
                                newPos[c] = currentPos[c];
                            newPos[current] = p;
                            queue.Enqueue(newPos);
                        }
                    }
                }
            }
        }

        return count;

    }
    
    public long Part2(string input)
    {
        var cards = input.Split(Environment.NewLine)
            .Select(Parse).ToArray();

        var total = 0L;
        for (var c=0; c<cards.Length;c++)
        {
            var card = cards[c];
            Console.WriteLine($"Card {c} of {cards.Length}");
            var springs = card.springs + "?" + card.springs + "?" + card.springs + "?" + card.springs + "?" +
                          card.springs;
            var positions = card.lengths.Concat(card.lengths).Concat(card.lengths)
                .Concat(card.lengths).Concat(card.lengths).ToArray();
            total+=Card((springs, positions));
        }
        return total;
    }
}