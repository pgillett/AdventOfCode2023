using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day19Test
{
    private Day19 _day19;

    [TestInitialize]
    public void Setup()
    {
        _day19 = new Day19();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe19114()
    {
        var expectedResult = 19114;
    
        var actualResult = _day19.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe368523()
    {
        var expectedResult = 368523;
    
        var actualResult = _day19.Part1(InputData.Day19);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe167409079868000()
    {
        var expectedResult = 167409079868000;
    
        var actualResult = _day19.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe124167549767307()
    {
        var expectedResult = 124167549767307;
    
        var actualResult = _day19.Part2(InputData.Day19);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"px{a<2006:qkq,m>2090:A,rfg}
pv{a>1716:R,A}
lnx{m>1548:A,A}
rfg{s<537:gd,x>2440:R,A}
qs{s>3448:A,lnx}
qkq{x<1416:A,crn}
crn{x>2662:A,R}
in{s<1351:px,qqz}
qqz{s>2770:qs,m<1801:hdj,R}
gd{a>3333:R,R}
hdj{m>838:A,pv}

{x=787,m=2655,a=1222,s=2876}
{x=1679,m=44,a=2067,s=496}
{x=2036,m=264,a=79,s=2244}
{x=2461,m=1339,a=466,s=291}
{x=2127,m=1623,a=2188,s=1013}";
}
