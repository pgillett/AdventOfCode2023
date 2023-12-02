using System;
using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day01Test
{
    private Day01 _day01;

    [TestInitialize]
    public void Setup()
    {
        _day01 = new Day01();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe142()
    {
        var expectedResult = 142;

        var actualResult = _day01.CalibrationSum(_test);

        actualResult.Should().Be(expectedResult);
    }

    [TestMethod]
    public void TestDataPart2ShouldBe281()
    {
        var expectedResult = 281;
    
        var actualResult = _day01.CalibrationSumLetters(_test2);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet";

    private string _test2 = @"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen";

}
