using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day20Test
{
    private Day20 _day20;

    [TestInitialize]
    public void Setup()
    {
        _day20 = new Day20();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe32000000()
    {
        var expectedResult = 32000000;
    
        var actualResult = _day20.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart1ShouldBe11687500()
    {
        var expectedResult = 11687500;
    
        var actualResult = _day20.Part1(_test2);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe819397964()
    {
        var expectedResult = 819397964;
    
        var actualResult = _day20.Part1(InputData.Day20);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe()
    {
        var expectedResult = 1;
    
        var actualResult = _day20.Part2(InputData.Day20);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"broadcaster -> a, b, c
%a -> b
%b -> c
%c -> inv
&inv -> a";

    private string _test2 = @"broadcaster -> a
%a -> inv, con
&inv -> b
%b -> con
&con -> output";
}
