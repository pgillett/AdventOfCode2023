using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day10Test
{
    private Day10 _day10;

    [TestInitialize]
    public void Setup()
    {
        _day10 = new Day10();
    }

    // [TestMethod]
    // public void TestDataPart1ShouldBe()
    // {
    //     var expectedResult = 0;
    //
    //     var actualResult = _day10.Part1(_test);
    //
    //     actualResult.Should().Be(expectedResult);
    // }
    //
    // [TestMethod]
    // public void TestDataPart2ShouldBe()
    // {
    //     var expectedResult = 0;
    //
    //     var actualResult = _day10.Part2(_test);
    //
    //     actualResult.Should().Be(expectedResult);
    // }

    private string _test = @"";
}
