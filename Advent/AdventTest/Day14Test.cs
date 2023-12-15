using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day14Test
{
    private Day14 _day14;

    [TestInitialize]
    public void Setup()
    {
        _day14 = new Day14();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe136()
    {
        var expectedResult = 136;
    
        var actualResult = _day14.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe113456()
    {
        var expectedResult = 113456;
    
        var actualResult = _day14.Part1(InputData.Day14);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe64()
    {
        var expectedResult = 64;
    
        var actualResult = _day14.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe118747()
    {
        var expectedResult = 118747; //118780;
    
        var actualResult = _day14.Part2(InputData.Day14);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....";
}
