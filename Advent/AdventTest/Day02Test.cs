using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day02Test
{
    private Day02 _day02;

    [TestInitialize]
    public void Setup()
    {
        _day02 = new Day02();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe8()
    {
        var expectedResult = 8;
    
        var actualResult = _day02.Sums(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe2286()
    {
        var expectedResult = 2286;
    
        var actualResult = _day02.Powers(_test);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
}
