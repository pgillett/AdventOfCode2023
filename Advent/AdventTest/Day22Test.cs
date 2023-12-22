using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day22Test
{
    private Day22 _day22;

    [TestInitialize]
    public void Setup()
    {
        _day22 = new Day22();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe5()
    {
        var expectedResult = 5;
    
        var actualResult = _day22.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe501()
    {
        var expectedResult = 501;
    
        var actualResult = _day22.Part1(InputData.Day22);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe7()
    {
        var expectedResult = 7;
    
        var actualResult = _day22.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe80948()
    {
        var expectedResult = 80948;
    
        var actualResult = _day22.Part2(InputData.Day22);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"1,0,1~1,2,1
0,0,2~2,0,2
0,2,3~2,2,3
0,0,4~0,2,4
2,0,5~2,2,5
0,1,6~2,1,6
1,1,8~1,1,9";
}
