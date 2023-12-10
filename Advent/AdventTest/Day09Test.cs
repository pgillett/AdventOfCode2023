using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day09Test
{
    private Day09 _day09;

    [TestInitialize]
    public void Setup()
    {
        _day09 = new Day09();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe114()
    {
        var expectedResult = 114;
    
        var actualResult = _day09.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe1995001648()
    {
        var expectedResult = 1995001648;
    
        var actualResult = _day09.Part1(InputData.Day09);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe2()
    {
        var expectedResult = 2;
    
        var actualResult = _day09.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe988()
    {
        var expectedResult = 988;
    
        var actualResult = _day09.Part2(InputData.Day09);
    
        actualResult.Should().Be(expectedResult);
    }
    

    private string _test = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";
}
