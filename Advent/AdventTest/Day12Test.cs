using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day12Test
{
    private Day12 _day12;

    [TestInitialize]
    public void Setup()
    {
        _day12 = new Day12();
    }

    // [TestMethod]
    // public void TestDataPart1ShouldBe()
    // {
    //     var expectedResult = 0;
    //
    //     var actualResult = _day12.Part1(_test);
    //
    //     actualResult.Should().Be(expectedResult);
    // }
    //
    // [TestMethod]
    // public void TestDataPart2ShouldBe()
    // {
    //     var expectedResult = 0;
    //
    //     var actualResult = _day12.Part2(_test);
    //
    //     actualResult.Should().Be(expectedResult);
    // }

    private string _test = @"";
}
