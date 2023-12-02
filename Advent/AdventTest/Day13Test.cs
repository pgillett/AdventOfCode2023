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

    // [TestMethod]
    // public void TestDataPart1ShouldBe()
    // {
    //     var expectedResult = 0;
    //
    //     var actualResult = _day13.Part1(_test);
    //
    //     actualResult.Should().Be(expectedResult);
    // }
    //
    // [TestMethod]
    // public void TestDataPart2ShouldBe()
    // {
    //     var expectedResult = 0;
    //
    //     var actualResult = _day13.Part2(_test);
    //
    //     actualResult.Should().Be(expectedResult);
    // }

    private string _test = @"";
}
