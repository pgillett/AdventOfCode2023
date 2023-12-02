using System;
using System.Linq;

namespace Advent;

public class Day02
{
    public int Sums(string input) =>
        input.Split(Environment.NewLine).Select(Result)
            .Where(result => result is { red: <= 12, green: <= 13, blue: <= 14 })
            .Sum(result => result.id);

    public int Powers(string input) =>
        input.Split(Environment.NewLine)
            .Select(Result)
            .Sum(result => result.red * result.green * result.blue);

    private (int id, int red, int green, int blue) Result(string game)
    {
        var split = game.Split(':', ';');

        var list = split.Skip(1)
            .SelectMany(show => show.Split(','))
            .Select(cube => cube.Trim().Split(' '))
            .Select(count => (colour: count[1], count: int.Parse(count[0])))
            .ToArray();

        return (int.Parse(split[0].Replace("Game ", "")), 
            FindMax(list, "red"), FindMax(list, "green"), FindMax(list, "blue"));
    }

    private int FindMax((string colour, int count)[] list, string colour) =>
        list.Where(c => c.colour == colour).Max(c => c.count);
}