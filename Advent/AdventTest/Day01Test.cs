using System;
using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day01Test
{
    private Day01 _day01;
    private Day01Tidy _day01Tidy;

    [TestInitialize]
    public void Setup()
    {
        _day01 = new Day01();
        _day01Tidy = new Day01Tidy();
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
    
    [TestMethod]
    public void RealDataPart1ShouldBe55538()
    {
        var expectedResult = 55538;

        var actualResult = _day01.CalibrationSum(InputData.Day01);

        actualResult.Should().Be(expectedResult);
    }

    [TestMethod]
    public void RealDataPart2ShouldBe54875()
    {
        var expectedResult = 54875;
    
        var actualResult = _day01.CalibrationSumLetters(InputData.Day01);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1TidyShouldBe55538()
    {
        var expectedResult = 55538;

        var actualResult = _day01Tidy.CalibrationSum(InputData.Day01);

        actualResult.Should().Be(expectedResult);
    }

    [TestMethod]
    public void RealDataPart2TidyShouldBe54875()
    {
        var expectedResult = 54875;
    
        var actualResult = _day01Tidy.CalibrationSumLetters(InputData.Day01);
    
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

// if (c < max - 3)
// {
//     if (chars[c] == 'o' && chars[c + 1] == 'n' && chars[c + 2] == 'e') return 1;
//     if (chars[c] == 't' && chars[c + 1] == 'w' && chars[c + 2] == 'o') return 2;
//     if (chars[c] == 's' && chars[c + 1] == 'i' && chars[c + 2] == 'x') return 6;
//
//     if (c < max - 4)
//     {
//         if (chars[c] == 'f' && chars[c + 1] == 'o' && chars[c + 2] == 'u' && chars[c + 3] == 'r') return 4;
//         if (chars[c] == 'f' && chars[c + 1] == 'i' && chars[c + 2] == 'v' && chars[c + 3] == 'e') return 5;
//         if (chars[c] == 'n' && chars[c + 1] == 'i' && chars[c + 2] == 'n' && chars[c + 3] == 'e') return 9;
//         if (chars[c] == 'z' && chars[c + 1] == 'e' && chars[c + 2] == 'r' && chars[c + 3] == 'o') return 0;
//
//         if (c < max - 5)
//         {
//             if (chars[c] == 't' && chars[c + 1] == 'h' && chars[c + 2] == 'r' && chars[c + 3] == 'e' && chars[c + 4] == 'e') return 3;
//             if (chars[c] == 's' && chars[c + 1] == 'e' && chars[c + 2] == 'v' && chars[c + 3] == 'e' && chars[c + 4] == 'n') return 7;
//             if (chars[c] == 'e' && chars[c + 1] == 'i' && chars[c + 2] == 'g' && chars[c + 3] == 'h' && chars[c + 4] == 't') return 8;
//         }
//     }
// }