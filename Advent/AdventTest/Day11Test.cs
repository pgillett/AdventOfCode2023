using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day11Test
{
    private Day11 _day11;

    [TestInitialize]
    public void Setup()
    {
        _day11 = new Day11();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe374()
    {
        var expectedResult = 374;
    
        var actualResult = _day11.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    
    [TestMethod]
    public void RealDataPart1ShouldBe9724940()
    {
        var expectedResult = 9724940;
    
        var actualResult = _day11.Part1(InputData.Day11);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe569052586852()
    {
        var expectedResult = 569052586852;
    
        var actualResult = _day11.Part2(InputData.Day11);
    
        actualResult.Should().Be(expectedResult);
    }
    
    
    [TestMethod]
    [DataRow(10, 1030)]
    [DataRow(100, 8410)]
    public void TestDataPart2ShouldBe(int gap, int expectedResult)
    {
        var actualResult = _day11.Shortest(_test, gap);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"...#......
.......#..
#.........
..........
......#...
.#........
.........#
..........
.......#..
#...#.....";
}
