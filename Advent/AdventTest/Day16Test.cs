using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day16Test
{
    private Day16 _day16;

    [TestInitialize]
    public void Setup()
    {
        _day16 = new Day16();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe46()
    {
        var expectedResult = 46;
    
        var actualResult = _day16.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void LiveDataPart1ShouldBe7482()
    {
        var expectedResult = 7482;
    
        var actualResult = _day16.Part1(InputData.Day16);
    
        actualResult.Should().Be(expectedResult);
    }
    
    
    [TestMethod]
    public void TestDataPart2ShouldBe51()
    {
        var expectedResult = 51;
    
        var actualResult = _day16.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe7896()
    {
        var expectedResult = 7896;
    
        var actualResult = _day16.Part2(InputData.Day16);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @".|...\....
|.-.\.....
.....|-...
........|.
..........
.........\
..../.\\..
.-.-/..|..
.|....-|.\
..//.|....";
}
