using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day21Test
{
    private Day21 _day21;

    [TestInitialize]
    public void Setup()
    {
        _day21 = new Day21();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe16()
    {
        var expectedResult = 16;
    
        var actualResult = _day21.Part1(_test, 6);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe3795()
    {
        var expectedResult = 3795;
    
        var actualResult = _day21.Part1(InputData.Day21, 64);
    
        actualResult.Should().Be(expectedResult);
    }
    //
    // [TestMethod]
    // public void TestDataPart2ShouldBe()
    // {
    //     var expectedResult = 0;
    //
    //     var actualResult = _day21.Part2(_test);
    //
    //     actualResult.Should().Be(expectedResult);
    // }

    private string _test = @"...........
.....###.#.
.###.##..#.
..#.#...#..
....#.#....
.##..S####.
.##..#...#.
.......##..
.##.#.####.
.##..##.##.
...........";
}
