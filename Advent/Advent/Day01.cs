using System;
using System.Linq;

namespace Advent;

public class Day01
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
            current.Replace(pair.search, pair.search + pair.replace + pair.search));

    private (string search, string replace)[] _numbers = new[]
    {
        ("one", "1"), ("two", "2"), ("three", "3"), ("four", "4"), ("five", "5"), ("six", "6"), ("seven", "7"),
        ("eight", "8"), ("nine", "9"), ("zero", "0")
    };
}