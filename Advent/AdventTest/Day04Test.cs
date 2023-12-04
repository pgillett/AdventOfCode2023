using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day04Test
{
    private Day04 _day04;

    [TestInitialize]
    public void Setup()
    {
        _day04 = new Day04();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe13()
    {
        var expectedResult = 13;
    
        var actualResult = _day04.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe30()
    {
        var expectedResult = 30;
    
        var actualResult = _day04.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";
}
