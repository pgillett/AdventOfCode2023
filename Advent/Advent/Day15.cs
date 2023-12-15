using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day15
{
    public int Part1(string input)
    {
        var split = input.Split(',');

        var total = 0;

        foreach (var value in split)
        {
            total += Hash(value);
        }
        
        return total;
    }

    public int Part2(string input)
    {
        var boxes = new LinkedList<Lens>[256];
        for (var i = 0; i < 256; i++)
            boxes[i] = new LinkedList<Lens>();

        var lenses = new Dictionary<string, Lens>();

        var c = 0;
        while (c < input.Length)
        {
            var f = c;
            while (char.IsLetter(input[c]))
                c++;

            var label = input.Substring(f, c - f);
            var op = input[c];
            c++;

            if (!lenses.ContainsKey(label))
                lenses[label] = new Lens(Hash(label));

            var lens = lenses[label];

            if (op == '-')
            {
                if (lens.InBox)
                {
                    boxes[lens.Hash].Remove(lens);
                    lens.InBox = false;
                }
            }
            else if (op == '=')
            {
                var focal = input[c] - '0';
                if (!lens.InBox)
                {
                    boxes[lens.Hash].AddLast(lens);
                    lens.InBox = true;
                }

                c++;

                lens.Focal = focal;
            }

            c++;
        }

        var total = 0;
        for (var b = 0; b < 256; b++)
        {
            var s = 1;
            foreach(var lens in boxes[b])
            {
                total += (b + 1) * s * lens.Focal;
                s++;
            }
        }

        return total;
    }

    public int Hash(string input)
    {
        var hash = 0;
        foreach (var v in input)
        {
            hash = (hash + v);
            hash = (hash + (hash << 4));
//            hash = ((hash + v) * 17) & 255;
        }

        return hash & 255;
    }
    
    public class Lens
    {
        public int Focal;
        public int Hash;
        public bool InBox;

        public Lens(int hash)
        {
            Hash = hash;
        }
    }
}