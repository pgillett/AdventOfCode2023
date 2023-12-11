using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day10Test
{
    private Day10 _day10;

    [TestInitialize]
    public void Setup()
    {
        _day10 = new Day10();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe8()
    {
        var expectedResult = 8;
    
        var actualResult = _day10.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe6823()
    {
        var expectedResult = 6823;
    
        var actualResult = _day10.Part1(InputData.Day10);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe4()
    {
        var expectedResult = 4;
    
        var actualResult = _day10.Part2(_test2);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe415()
    {
        var expectedResult = 415;
    
        var actualResult = _day10.Part2(InputData.Day10);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"7-F7-
.FJ|7
SJLL7
|F--J
LJ.LJ";

    private string _test2 = @"...........
.S-------7.
.|F-----7|.
.||.....||.
.||.....||.
.|L-7.F-J|.
.|..|.|..|.
.L--J.L--J.
...........";
}
