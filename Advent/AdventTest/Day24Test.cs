using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day24Test
{
    private Day24 _day24;

    [TestInitialize]
    public void Setup()
    {
        _day24 = new Day24();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe2()
    {
        var expectedResult = 2;
    
        var actualResult = _day24.Part1(_test, false);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe23760()
    {
        var expectedResult = 23760;
    
        var actualResult = _day24.Part1(InputData.Day24, true);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe()
    {
        var expectedResult = 0;
    
        var actualResult = _day24.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe()
    {
        var expectedResult = 0;
    
        var actualResult = _day24.Part2(InputData.Day24);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"19, 13, 30 @ -2,  1, -2
18, 19, 22 @ -1, -1, -2
20, 25, 34 @ -2, -2, -4
12, 31, 28 @ -1, -2, -1
20, 19, 15 @  1, -5, -3";
}
