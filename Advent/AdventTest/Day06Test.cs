using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day06Test
{
    private Day06 _day06;

    [TestInitialize]
    public void Setup()
    {
        _day06 = new Day06();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe288()
    {
        var expectedResult = 288;
    
        var actualResult = _day06.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe71503()
    {
        var expectedResult = 71503;
    
        var actualResult = _day06.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe4403592()
    {
        var expectedResult = 4403592;
    
        var actualResult = _day06.Part1(InputData.Day06);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe38017587()
    {
        var expectedResult = 38017587;
    
        var actualResult = _day06.Part2(InputData.Day06);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2MathsShouldBe38017587()
    {
        var expectedResult = 38017587;
    
        var actualResult = _day06.Part2Maths(InputData.Day06);
    
        actualResult.Should().Be(expectedResult);
    }

    [TestMethod]
    public void RealDataPart2NoParseShouldBe38017587()
    {
        var expectedResult = 38017587;
    
        var actualResult = _day06.Part2NoParse(InputData.Day06);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2SearchNoParseShouldBe38017587()
    {
        var expectedResult = 38017587;
    
        var actualResult = _day06.Part2SearchNoParse(InputData.Day06);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"Time:      7  15   30
Distance:  9  40  200";
}
