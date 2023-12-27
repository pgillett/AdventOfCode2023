using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day25
{
    public int Part1(string input)
    {
        var nodes = new Dictionary<string, Node>();
        var links = new Dictionary<(Node from, Node to), int>();
        
        foreach (var l in input.Split(Environment.NewLine))
        {
            var from = l.Substring(0, 3);
            var toList = l.Substring(5).Split(' ');
            if (!nodes.ContainsKey(from))
                nodes[from] = new Node();
            foreach (var to in toList)
            {
                if (!nodes.ContainsKey(to))
                    nodes[to] = new Node();
                nodes[from].Connections.Add(nodes[to]);
                nodes[to].Connections.Add(nodes[from]);
                links[(nodes[from], nodes[to])] = 0;
            }
        }
        
        foreach (var link1 in links.Keys)
        {
            var shortest = Shortest(nodes, link1.from, link1.to, link1, (null, null), (null, null));
            links[link1] = shortest.Value;
        }
        
        var longest1 = links.OrderByDescending(k => k.Value)
            .Select(k => k.Key).ToArray();

        foreach (var link1 in longest1)
        {
            foreach (var link2 in links.Keys)
            {
                var shortest = Shortest(nodes, link1.from, link1.to, link1, link2, (null, null));
                links[link2] = shortest.Value;
            }
            
            var longest2 = links.OrderByDescending(k => k.Value)
                .Select(k => k.Key).ToArray();
            
            foreach (var link2 in longest2)
            {
                foreach (var link3 in links.Keys)
                {
                    var shortest = Shortest(nodes, link1.from, link1.to, link1, link2, link3);
                    if (shortest == null)
                        return Sizes(nodes, link1, link2, link3);
                }
            }
        }

        throw new Exception();
    }

    private int Sizes(Dictionary<string, Node> nodes, (Node, Node) exclude1, (Node, Node) exclude2, (Node, Node) exclude3)
    {
        var thisLoop = 0;
        var otherLoop = 0;
        var from = exclude1.Item1;
        foreach (var node in nodes.Values)
        {
            if (Shortest(nodes, from, node, exclude1, exclude2, exclude3) == null)
            {
                otherLoop++;
            }
            else
            {
                thisLoop++;
            }
        }

        return thisLoop * otherLoop;
    }


    private int? Shortest(Dictionary<string, Node> dictionary, Node first, Node last, (Node, Node) exclude1, (Node, Node) exclude2, (Node, Node) exclude3)
    {
        foreach (var node in dictionary.Values)
            node.Seen = false;
        
        var stack = new Queue<(Node node, int step)>();

        stack.Enqueue((first, 0));

        while (stack.Count > 0)
        {
            var next = stack.Dequeue();
            if (next.node == last)
                return next.step;
            if(next.node.Seen)
                    continue;
            next.node.Seen = true;

            foreach (var node in next.node.Connections.Where(node => (exclude1.Item1 != next.node || exclude1.Item2 != node)
                                                                     && (exclude1.Item2 != next.node || exclude1.Item1 != node)
                                                                     && (exclude2.Item1 != next.node || exclude2.Item2 != node)
                                                                     && (exclude2.Item2 != next.node || exclude2.Item1 != node)
                                                                     && (exclude3.Item1 != next.node || exclude3.Item2 != node)
                                                                     && (exclude3.Item2 != next.node || exclude3.Item1 != node)))
            {
                stack.Enqueue((node, next.step + 1));
            }
        }

        return null;
    }

    public class Node
    {
        public List<Node> Connections = new List<Node>();
        public bool Seen;
    }

    public int Part2(string input)
    {
        return 0;
    }
}