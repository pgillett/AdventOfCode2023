using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day13Test
{
    private Day13 _day13;

    [TestInitialize]
    public void Setup()
    {
        _day13 = new Day13();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe405()
    {
        var expectedResult = 405;
    
        var actualResult = _day13.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe27202()
    {
        var expectedResult = 27202;
    
        var actualResult = _day13.Part1(InputData.Day13);
    
        actualResult.Should().Be(expectedResult);
    }
    
    
    [TestMethod]
    public void TestDataPart2ShouldBe400()
    {
        var expectedResult = 400;
    
        var actualResult = _day13.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe41566()
    {
        var expectedResult = 41566;
    
        var actualResult = _day13.Part2(InputData.Day13);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"#.##..##.
..#.##.#.
##......#
##......#
..#.##.#.
..##..##.
#.#.##.#.

#...##..#
#....#..#
..##..###
#####.##.
#####.##.
..##..###
#....#..#";
}
