using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day08Test
{
    private Day08 _day08;

    [TestInitialize]
    public void Setup()
    {
        _day08 = new Day08();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe2()
    {
        var expectedResult = 2;
    
        var actualResult = _day08.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart1ShouldBe6()
    {
        var expectedResult = 6;
    
        var actualResult = _day08.Part1(_test2);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe16897()
    {
        var expectedResult = 16897;
    
        var actualResult = _day08.Part1(InputData.Day08);
    
        actualResult.Should().Be(expectedResult);
    }
    
    
    [TestMethod]
    public void TestDataPart2ShouldBe6()
    {
        var expectedResult = 6;
    
        var actualResult = _day08.Part2(_test3);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe16563603485021()
    {
        var expectedResult = 16563603485021;
    
        var actualResult = _day08.Part2(InputData.Day08);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2aShouldBe16563603485021()
    {
        var expectedResult = 16563603485021;
    
        var actualResult = _day08.Part2a(InputData.Day08);
    
        actualResult.Should().Be(expectedResult);
    }
    
// 1880032569870193489
// 16563603485021
    
    [TestMethod]
    public void LowestCommon()
    {
        _day08.LowestCommon(new[] { 2, 6 }).Should().Be(6);
        _day08.LowestCommon(new[] { 12, 6 }).Should().Be(12);
        _day08.LowestCommon(new[] { 10, 15 }).Should().Be(30);
        _day08.LowestCommon(new[] { 10, 15, 20 }).Should().Be(60);
        _day08.LowestCommon(new[] { 2, 3, 4 }).Should().Be(12);
        _day08.LowestCommon(new[] { 5, 3, 4 }).Should().Be(60);
        _day08.LowestCommon(new[] { 5, 3, 6 }).Should().Be(30);
        _day08.LowestCommon(new[] { 100, 150, 200 }).Should().Be(600);
        _day08.LowestCommon(new[] { 200, 150, 100 }).Should().Be(600);
    }

    private string _test = @"RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)";
    
    private string _test2 = @"LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)";

    private string _test3 = @"LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)";
}
