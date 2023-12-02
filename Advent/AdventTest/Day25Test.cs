using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day25Test
{
    private Day25 _day25;

    [TestInitialize]
    public void Setup()
    {
        _day25 = new Day25();
    }

    // [TestMethod]
    // public void TestDataPart1ShouldBe()
    // {
    //     var expectedResult = 0;
    //
    //     var actualResult = _day25.Part1(_test);
    //
    //     actualResult.Should().Be(expectedResult);
    // }
    //
    // [TestMethod]
    // public void TestDataPart2ShouldBe()
    // {
    //     var expectedResult = 0;
    //
    //     var actualResult = _day25.Part2(_test);
    //
    //     actualResult.Should().Be(expectedResult);
    // }

    private string _test = @"";
}
