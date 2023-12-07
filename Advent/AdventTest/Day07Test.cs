using System;
using System.Linq;
using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day07Test
{
    private Day07 _day07;
    private Day07Opt _day07Opt;

    [TestInitialize]
    public void Setup()
    {
        _day07 = new Day07();
        _day07Opt = new Day07Opt();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe6440()
    {
        var expectedResult = 6440;
    
        var actualResult = _day07.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe5905()
    {
        var expectedResult = 5905;
    
        var actualResult = _day07.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
   
    [TestMethod]
    public void RealDataPart1ShouldBe251545216()
    {
        var expectedResult = 251545216;
    
        var actualResult = _day07.Part1(InputData.Day07);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe250384185()
    {
        var expectedResult = 250384185;
    
        var actualResult = _day07.Part2(InputData.Day07);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2OptShouldBe250384185()
    {
        var expectedResult = 250384185;
        
        var actualResult = _day07Opt.Part2Opt(InputData.Day07);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";
}
