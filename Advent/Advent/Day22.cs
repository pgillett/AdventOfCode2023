using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day22
{
    public int Part1(string input)
    {
        var bricks = input.Split(Environment.NewLine)
            .Select(l => new Brick(l))
            .ToArray();

        var falling = true;
        
//        bricks = bricks.OrderBy(b => int.Min(b.FromZ, b.ToZ)).ToArray();

        while (falling)
        {
            falling = false;
            foreach (var brick in bricks.Where(b => b.FromZ > 1))
            {
                if (!bricks.Any(c =>
                        c.ToZ == brick.FromZ - 1 && brick.OverlapXY(c)))
                {
                    brick.FromZ--;
                    brick.ToZ--;
                    falling = true;
                }
            }
        }

        var count = 0;
        
        foreach (var brick in bricks)
        {
            var allSupporting = bricks.Where(c =>
                c.FromZ == brick.ToZ + 1 && brick.OverlapXY(c)).ToArray();

            brick.Supporting = allSupporting;
            
            foreach (var supports in allSupporting)
            {
                supports.NoOfSupports++;
            }
        }

        foreach (var brick in bricks)
        {
            if (!brick.Supporting.Any(b => b.NoOfSupports < 2))
            {
                count++;
            }
        }
        
        return count;
    }

    public class Brick
    {
        public int FromX;
        public int FromY;
        public int FromZ;
        public int ToX;
        public int ToY;
        public int ToZ;
        public bool Stopped;

        public Brick[] Supporting;
        public int NoOfSupports;
        public List<Brick> SupportedBy = new List<Brick>();

        public bool OverlapXY(Brick c)
        {
            return c.FromX <= ToX && c.ToX >= FromX &&
                   c.FromY <= ToY && c.ToY >= FromY;
        }

        public int TotalSupports(HashSet<Brick> seen)
        {
            if (seen.Contains(this)) return 0;
            seen.Add(this);
            return 1 + (Supporting?.Sum(b => b.TotalSupports(seen)) ?? 0);
        }

        public bool OnX => FromX != ToX;
        public bool OnY => FromY != ToY;
        public bool OnZ => FromZ != ToZ;

        public Brick(string input)
        {
            var l = input.Split(',', '~').Select(int.Parse).ToArray();
            FromX = l[0];
            FromY = l[1];
            FromZ = l[2];
            ToX = l[3];
            ToY = l[4];
            ToZ = l[5];
            if (ToZ < FromZ || ToY < FromY || ToX < FromX)
                throw new Exception(input);
        }
    }

    public int Part2(string input)
    
    {
        var bricks = input.Split(Environment.NewLine)
            .Select(l => new Brick(l))
            .ToArray();

        var falling = true;

        while (falling)
        {
            falling = false;
            foreach (var brick in bricks.Where(b => b.FromZ > 1))
            {
                if (!bricks.Any(c =>
                        c.ToZ == brick.FromZ - 1 && brick.OverlapXY(c)))
                {
                    brick.FromZ--;
                    brick.ToZ--;
                    falling = true;
                }
            }
        }
        
        foreach (var brick in bricks)
        {
            var allSupporting = bricks.Where(c =>
                c.FromZ == brick.ToZ + 1 && brick.OverlapXY(c)).ToArray();

            brick.Supporting = allSupporting;
            
            foreach (var supports in allSupporting)
            {
                supports.SupportedBy.Add(brick);
                supports.NoOfSupports++;
            }
        }

        var totalCount = 0;
        
        foreach (var brick in bricks)
        {
            var seen = new HashSet<Brick>();
            var queue = new Queue<Brick>();
            var count = 0;
            queue.Enqueue(brick);
            
            while (queue.Count > 0)
            {
                var move = queue.Dequeue();
                if(seen.Contains(move)) continue;
                count++;
                seen.Add(move);
                foreach (var supports in move.Supporting)
                {
                    var supportedBy = supports.SupportedBy.ToHashSet();
                    foreach (var remove in seen)
                        supportedBy.Remove(remove);

                    if (supportedBy.Count == 0)
                        queue.Enqueue(supports);
                }
            }

            Debug.WriteLine(count - 1);
            totalCount += count - 1;
        }

        return totalCount;
    }
}