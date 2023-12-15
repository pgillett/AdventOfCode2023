using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day15Test
{
    private Day15 _day15;

    [TestInitialize]
    public void Setup()
    {
        _day15 = new Day15();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe1320()
    {
        var expectedResult = 1320;
    
        var actualResult = _day15.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe504036()
    {
        var expectedResult = 504036;
    
        var actualResult = _day15.Part1(InputData.Day15);
    
        actualResult.Should().Be(expectedResult);
    }
    
    
    [TestMethod]
    public void TestDataPart2ShouldBe145()
    {
        var expectedResult = 145;
    
        var actualResult = _day15.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe295719()
    {
        var expectedResult = 295719;
    
        var actualResult = _day15.Part2(InputData.Day15);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7";
}
