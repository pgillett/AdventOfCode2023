using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day03Test
{
    private Day03 _day03;

    [TestInitialize]
    public void Setup()
    {
        _day03 = new Day03();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe4361()
    {
        var expectedResult = 4361;
    
        var actualResult = _day03.SumParts(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe467835()
    {
        var expectedResult = 467835;
    
        var actualResult = _day03.GearRatios(_test);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";
}
