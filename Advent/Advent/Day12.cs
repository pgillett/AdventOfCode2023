using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CommandLine;

namespace Advent;

public class Day12
{
    public int Part1(string input)
    {
        var cards = input.Split(Environment.NewLine)
            .Select(l => new CardData(Parse(l))).ToArray();

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

    public class CardData
    {
        public string Springs;
        public int[] Lengths;
        public int[] Left;
        public int[] Totals;
        public int[] Min;
        public int[] Used;
        public int[] Ends;
        public int[] Could;

        public CardData((string springs, int[] lengths) input)
        {
            Springs = input.springs;
            Lengths = input.lengths;
            
            Left = new int[Springs.Length];
            Totals = new int[Lengths.Length];
            Min = new int[Springs.Length];
            Used = new int[Lengths.Length];
            Ends = new int[Lengths.Length];
            {
                var totalFixed = Springs.Count(c => c == '#');
                {
                    var total = 0;
                    for (var c = 0; c < Springs.Length; c++)
                    {
                        if (Springs[c] == '#')
                            total++;
                        Min[c] = total;
                        Left[c] = totalFixed - total;
                    }

                    total = Lengths.Sum();
                    var use = 0;
                    for (var t = 0; t < Lengths.Length; t++)
                    {
                        Used[t] = use;
                        use += Lengths[t];
                        Totals[t] = total;
                        total -= Lengths[t];
                    }

                    total = Springs.Length;
                    for (var t = Lengths.Length - 1; t >= 0; t--)
                    {
                        total -= Lengths[t];
                        Ends[t] = total;
                        total -= 1;
                    }
                }
            }

            Could = new int[Springs.Length+1];
            Could[0] = 0;
            for (var i = 1; i < Springs.Length+1; i++)
                Could[i] = Could[i - 1] + (Springs[i-1] != '.' ? 1 : 0);

        }
    }

    public int Card(CardData card)
    {
        var minLength = card.Lengths.Sum() + card.Lengths.Length - 1;

        var queue = new Queue<int[]>();

        var currentPos = new int[0];

        queue.Enqueue(currentPos);
        
        Debug.WriteLine("");
        Debug.WriteLine($"{card.Springs} {string.Join(',',card.Lengths)}");
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
                next = currentPos[^1] + card.Lengths[currentPos.Length - 1] + 1;
                current = currentPos.Length;
            }

            if (current != lastCurrent)
                lastCurrent = current;

            var end = card.Ends[current];
            
            {
                for (var p = next; p <= end; p++)
                {
                    if (p > 0 && card.Springs[p - 1] == '#')
                        break;
                    
                    if(card.Springs[p] == '.')
                        continue;
                    
                    var match = true;

                    {
                        var after = p + card.Lengths[current];
                        if (after < card.Springs.Length && card.Springs[after] == '#')
                            match = false;
                    }

                    {
                        if (card.Totals[current] <= (card.Left[p]-1))
                            match = false;
                        if (p > 0 && card.Min[p - 1] > card.Used[current])
                            continue;
//                            match = false;
                    }

                    if (match)
                    {
                        match = card.Could[p + card.Lengths[current]] - card.Could[p] == card.Lengths[current];
                    }
                    

                    if (match)
                    {
                        if (current == card.Lengths.Length - 1)
                        {
                            var all = true;
                            for (var check = p+card.Lengths[current]; check < card.Springs.Length; check++)
                            {
                                if (card.Springs[check] == '#')
                                {
                                    all = false;
                                    break;
                                }
                            }

                            if (all)
                            {
                                var chars = new char[card.Springs.Length];
                                Array.Fill(chars, '.');
                                for (var s = 0; s < card.Lengths.Length; s++)
                                {
                                    var from = s < card.Lengths.Length - 1 ? currentPos[s] : p;
                                    for (var f = 0; f < card.Lengths[s]; f++)
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
            total+=Card(new CardData((springs, positions)));
        }
        return total;
    }
}