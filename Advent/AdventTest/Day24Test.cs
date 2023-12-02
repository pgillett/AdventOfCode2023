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

    // [TestMethod]
    // public void TestDataPart1ShouldBe()
    // {
    //     var expectedResult = 0;
    //
    //     var actualResult = _day24.Part1(_test);
    //
    //     actualResult.Should().Be(expectedResult);
    // }
    //
    // [TestMethod]
    // public void TestDataPart2ShouldBe()
    // {
    //     var expectedResult = 0;
    //
    //     var actualResult = _day24.Part2(_test);
    //
    //     actualResult.Should().Be(expectedResult);
    // }

    private string _test = @"";
}
