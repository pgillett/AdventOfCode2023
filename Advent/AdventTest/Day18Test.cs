using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day18Test
{
    private Day18 _day18;

    [TestInitialize]
    public void Setup()
    {
        _day18 = new Day18();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe62()
    {
        var expectedResult = 62;
    
        var actualResult = _day18.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe62365()
    {
        var expectedResult = 62365;
    
        var actualResult = _day18.Part1(InputData.Day18);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe952408144115()
    {
        var expectedResult = 952408144115;
    
        var actualResult = _day18.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe159485361249806()
    {
        var expectedResult = 159485361249806;
    
        var actualResult = _day18.Part2(InputData.Day18);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"R 6 (#70c710)
D 5 (#0dc571)
L 2 (#5713f0)
D 2 (#d2c081)
R 2 (#59c680)
D 2 (#411b91)
L 5 (#8ceee2)
U 2 (#caa173)
L 1 (#1b58a2)
U 2 (#caa171)
R 2 (#7807d2)
U 3 (#a77fa3)
L 2 (#015232)
U 2 (#7a21e3)";
}
