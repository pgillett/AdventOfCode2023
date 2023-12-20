using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day19
{
    public int Part1(string input)
    {
        var split = input.Split(Environment.NewLine + Environment.NewLine);

        var workloads = split[0].Split(Environment.NewLine).Select(ParseWorkflow)
            .ToDictionary(w => w.name, w => w.rules);

        var total = 0;
        
        foreach (var part in split[1].Split(Environment.NewLine).Select(ParsePart))
        {
            var current = "in";
            while (current != "R" && current != "A")
            {
                current = workloads[current].First(rule => (rule.index == -1) ||
                                                           (rule.greater && part[rule.index] > rule.value) ||
                                                           (!rule.greater && part[rule.index] < rule.value)).target;
            }

            if (current == "A")
            {
                total += part.Sum();
            }
        }
        
        return total;
    }

    public (string name, List<(int index, bool greater, int value, string target)> rules) ParseWorkflow(string input)
    {
        var split = input.Split(new[] { '{', ',', '}' }, StringSplitOptions.RemoveEmptyEntries);
        var ret = new List<(int, bool, int, string)>();

        foreach (var rule in split.Skip(1))
        {
            if (!rule.Contains(':'))
                ret.Add((-1, false, 0, rule));
            else
            {
                var split2 = rule[2..].Split(':');
                ret.Add(("xmas".IndexOf(rule[0]), rule[1] == '>', int.Parse(split2[0]), split2[1]));
            }
        }

        return (split[0], ret);
    }
    
    public int[] ParsePart(string input)
    {
        var split = input.Split(new[] { ',', '{', '=', '}' }, StringSplitOptions.RemoveEmptyEntries);
        return new[] { split[1], split[3], split[5], split[7] }.Select(int.Parse).ToArray();
    }

    public long Part2(string input)
    {
        var split = input.Split(Environment.NewLine + Environment.NewLine);

        var workloads = split[0].Split(Environment.NewLine).Select(ParseWorkflow)
            .ToDictionary(w => w.name, w => w.rules);

        var total = 0L;

        var queue = new Queue<(string rule, (int lower, int upper)[] values)>();

        queue.Enqueue(("in", new[] { (1, 4000), (1, 4000), (1, 4000), (1, 4000) }));

        while (queue.Count > 0)
        {
            var step = queue.Dequeue();

            if (step.rule == "A")
            {
                var sub = 1L;
                foreach (var value in step.values)
                    sub *= (value.upper - value.lower + 1);
                total += sub;
            }
            else if (step.rule != "R")
            {
                var rules = workloads[step.rule];
                foreach (var rule in rules)
                {
                    if (rule.index == -1)
                    {
                        queue.Enqueue((rule.target, step.values));
                        break;
                    }

                    if (rule.greater)
                    {
                        if (step.values[rule.index].upper > rule.value)
                        {
                            var newValues = step.values.ToArray();
                            newValues[rule.index].lower = rule.value + 1;
                            queue.Enqueue((rule.target, newValues));
                            step.values[rule.index].upper = rule.value;
                        }
                    }

                    if (!rule.greater)
                    {
                        if (step.values[rule.index].lower < rule.value)
                        {
                            var newValues = step.values.ToArray();
                            newValues[rule.index].upper = rule.value - 1;
                            queue.Enqueue((rule.target, newValues));
                            step.values[rule.index].lower = rule.value;
                        }
                    }
                }
            }
        }

        return total;
    }
}