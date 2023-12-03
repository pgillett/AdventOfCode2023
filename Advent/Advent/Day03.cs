using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent;

public class Day03
{
    public int SumParts(string input) => 
        Parse(input).numbers.Where(n => n.near).Sum(n => n.number);

    public int GearRatios(string input)
    {
        var (numbers, gears) = Parse(input);

        return gears.Where(g => g.Value.Count == 2)
            .Sum(gear => numbers[gear.Value[0]].number * numbers[gear.Value[1]].number);
    }

    private (List<(int number, bool near)> numbers, Dictionary<(int, int), List<int>> gears) Parse(string input)
    {
        var rows = input.Split(Environment.NewLine);
        var numbers = new List<(int number, bool near)>();
        var gears = new Dictionary<(int, int), List<int>>();

        bool extending;
        for (var row = 0; row < rows.Length; row++)
        {
            extending = false;
            for (var col = 0; col < rows[0].Length; col++)
            {
                if (char.IsDigit(rows[row][col]))
                {
                    if (!extending) 
                        numbers.Add((0, false));
                    
                    var near = numbers[^1].Item2;

                    var startCol = extending ? 1 : col > 0 ? -1 : 0;
                    var endCol = col < rows[0].Length - 1 ? 1 : 0;
                    var endRow = row < rows.Length - 1 ? 1 : 0;

                    for (var deltaRow = row > 0 ? -1 : 0; deltaRow <= endRow; deltaRow++)
                    for (var deltaCol = startCol; deltaCol <= endCol; deltaCol++)
                        if (deltaRow != 0 || deltaCol != 0)
                        {
                            var checkRow = row + deltaRow;
                            var checkCol = col + deltaCol;

                            var at = rows[checkRow][checkCol];
                            if (at != '.' && !char.IsDigit(at))
                            {
                                near = true;

                                if (at == '*')
                                {
                                    if (!gears.ContainsKey((checkRow, checkCol)))
                                        gears[(checkRow, checkCol)] = new List<int>();

                                    gears[(checkRow, checkCol)].Add(numbers.Count - 1);
                                }
                            }
                        }

                    numbers[^1] = (numbers[^1].Item1 * 10 + (rows[row][col] - '0'), near);
                    extending = true;
                }
                else
                {
                    extending = false;
                }
            }
        }

        return (numbers, gears);
    }
}