using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent;

public class Day23
{
    public int Part1(string input) => Check(input, true);

    public class Node
    {
        public int Y;
        public int X;
        public int No;

        public Dictionary<Node, int> Joins = new Dictionary<Node, int>();

        public Node(int y, int x, int no)
        {
            X = x;
            Y = y;
            No = no;
        }

        public string Coords() => $"({Y},{X})";

        public override string ToString()
        {
            return $"{No}. {Coords()} -> " +
                   string.Join(", ", Joins.Select(kvp => $"{kvp.Key.No}. {kvp.Key.Coords()}+{kvp.Value}"));
        }
    }

    public int Part2(string input) => Check(input, false);

    public int Check(string input, bool hills)
    {
        var map = input.Split(Environment.NewLine);

        var routes = new List<int>();

        var start = new Node(0, 1, 0);

        var nodes = GetNodes(start, map, hills);

        var stack = new Stack<(Node node, int step, long status)>();
        stack.Push((start, 0, 0L));

        var end = nodes[(map.Length - 1, map[0].Length - 2)];

        while (stack.Count > 0)
        {
            var pos = stack.Pop();
            if (pos.node == end)
            {
                routes.Add(pos.step);
                continue;
            }

            foreach (var to in pos.node.Joins)
            {
                if ((pos.status & (1L << to.Key.No)) == 0)
                    stack.Push((to.Key, pos.step + to.Value, pos.status | (1L << to.Key.No)));
            }
        }

        return routes.Max();
    }

    public Dictionary<(int y, int x), Node> GetNodes(Node start, string[] map, bool hills)
    {
        var nodes = new Dictionary<(int y, int x), Node>();
        nodes.Add((start.Y, start.X), start);

        var queue = new Queue<(int y, int x, int step, (int y, int x) previous, Node lastNode)>();
        queue.Enqueue((0, 1, 0, (0, 0), start));

        var blocks = hills ? new[] { ".^", ".v", ".<", ".>" } : new[] { ".^v<>", ".^v<>", ".^v<>", ".^v<>" };
        var nodeNo = 0;
        while (queue.Count > 0)
        {
            var pos = queue.Dequeue();

            var previous = pos.previous;
            var nodeCount = 0;
            if (pos.y > 1 && map[pos.y - 1][pos.x] != '#') nodeCount++;
            if (pos.y < map.Length - 1 && map[pos.y + 1][pos.x] != '#') nodeCount++;
            if (map[pos.y][pos.x - 1] != '#') nodeCount++;
            if (map[pos.y][pos.x + 1] != '#') nodeCount++;

            var step = pos.step;
            var lastNode = pos.lastNode;

            var nextPrevious = (pos.y, pos.x);
            if (nodeCount > 2 || pos.y == map.Length - 1)
            {
                if (!nodes.TryGetValue((pos.y, pos.x), out var node))
                {
                    nodeNo++;
                    node = new Node(pos.y, pos.x, nodeNo);
                    nodes[(pos.y, pos.x)] = node;
                }

                if (lastNode.Joins.ContainsKey(node))
                    continue;
                lastNode.Joins[node] = step;
                lastNode = node;
                step = 0;
                previous = (0, 0);
            }

            if (pos.y > 1 && blocks[0].Contains(map[pos.y - 1][pos.x]) &&
                (pos.y - 1 != previous.y || pos.x != previous.x))
            {
                queue.Enqueue((pos.y - 1, pos.x, step + 1, nextPrevious, lastNode));
            }

            if (pos.y < map.Length - 1 && blocks[1].Contains(map[pos.y + 1][pos.x]) &&
                (pos.y + 1 != previous.y || pos.x != previous.x))
            {
                queue.Enqueue((pos.y + 1, pos.x, step + 1, nextPrevious, lastNode));
            }

            if (blocks[2].Contains(map[pos.y][pos.x - 1]) && (pos.y != previous.y || pos.x - 1 != previous.x))
            {
                queue.Enqueue((pos.y, pos.x - 1, step + 1, nextPrevious, lastNode));
            }

            if (blocks[3].Contains(map[pos.y][pos.x + 1]) && (pos.y != previous.y || pos.x + 1 != previous.x))
            {
                queue.Enqueue((pos.y, pos.x + 1, step + 1, nextPrevious, lastNode));
            }
        }

        return nodes;
    }
}