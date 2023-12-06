using System;
using System.Linq;

namespace Advent;

public class Day01
{
    public int CalibrationSum(string input) =>
        input.Split(Environment.NewLine).Select(Value)
            .Sum();

    private int Value(string input) => 10 * (input.First(char.IsDigit) - '0') + (input.Last(char.IsDigit) - '0');

    public int CalibrationSumLetters(string input)
    {
        var total = 0;
        var c = 0;
        while (c < input.Length)
        {
            var end = c;
            while (end < input.Length)
            {
                if (input[end] == 10) break;
                end++;
            }

            if (end - c > 2) total += GetTotal(input, c, end - 1);

            c = end + 1;
        }

        return total;
    }
    
    private int GetTotal(string input, int from, int to)
    {
        return Get(input, from, to + 1, 1, to) * 10 +
               Get(input, to,from - 1, -1, to);
    }
    
    private int Get(string chars, int from, int to, int direction, int max)
    {
        for (var c = from; c != to; c += direction)
        {
            if (chars[c] >= '0' && chars[c] <= '9')
                return chars[c] - '0';

            if (c < max - 1)
            {
                if (chars[c] == 'o' && chars[c + 1] == 'n' && chars[c + 2] == 'e') return 1;
                if (chars[c] == 't' && chars[c + 1] == 'w' && chars[c + 2] == 'o') return 2;
                if (chars[c] == 's' && chars[c + 1] == 'i' && chars[c + 2] == 'x') return 6;

                if (c < max - 2)
                {
                    if (chars[c] == 'f' && chars[c + 1] == 'o' && chars[c + 2] == 'u' && chars[c + 3] == 'r') return 4;
                    if (chars[c] == 'f' && chars[c + 1] == 'i' && chars[c + 2] == 'v' && chars[c + 3] == 'e') return 5;
                    if (chars[c] == 'n' && chars[c + 1] == 'i' && chars[c + 2] == 'n' && chars[c + 3] == 'e') return 9;
                    if (chars[c] == 'z' && chars[c + 1] == 'e' && chars[c + 2] == 'r' && chars[c + 3] == 'o') return 0;

                    if (c < max - 3)
                    {
                        if (chars[c] == 't' && chars[c + 1] == 'h' && chars[c + 2] == 'r' && chars[c + 3] == 'e' && chars[c + 4] == 'e') return 3;
                        if (chars[c] == 's' && chars[c + 1] == 'e' && chars[c + 2] == 'v' && chars[c + 3] == 'e' && chars[c + 4] == 'n') return 7;
                        if (chars[c] == 'e' && chars[c + 1] == 'i' && chars[c + 2] == 'g' && chars[c + 3] == 'h' && chars[c + 4] == 't') return 8;
                    }
                }
            }
        }

        return -1;
    }
}

public class Day01Tidy
{
    public int CalibrationSum(string input) =>
        input.Split(Environment.NewLine).Select(Value)
            .Sum();

    private int Value(string input) => int.Parse($"{input.First(char.IsDigit)}{input.Last(char.IsDigit)}");

    public int CalibrationSumLetters(string input) =>
        input.Split(Environment.NewLine).Select(ReplaceWords).Select(Value)
            .Sum();

    private string ReplaceWords(string input) =>
        _numbers.Aggregate(input, (current, pair) => 
            current.Replace(pair.search, pair.replace));

    private (string search, string replace)[] _numbers = new[]
    {
        ("one", "o1e"), ("two", "t2o"), ("three", "t3ree"), ("four", "f4ur"), ("five", "f5ve"), ("six", "s6x"), ("seven", "s7ven"),
        ("eight", "e8ght"), ("nine", "n9ne"), ("zero", "z0ro")
    };
}