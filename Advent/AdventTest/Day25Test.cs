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

    [TestMethod]
    public void TestDataPart1ShouldBe54()
    {
        var expectedResult = 54;
    
        var actualResult = _day25.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe547080()
    {
        var expectedResult = 547080;
    
        var actualResult = _day25.Part1(InputData.Day25);
    
        actualResult.Should().Be(expectedResult);
    }
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

    private string _test = @"jqt: rhn xhk nvd
rsh: frs pzl lsr
xhk: hfx
cmg: qnr nvd lhk bvb
rhn: xhk bvb hfx
bvb: xhk hfx
pzl: lsr hfx nvd
qnr: nvd
ntq: jqt hfx bvb xhk
nvd: lhk
lsr: lhk
rzs: qnr cmg lsr rsh
frs: qnr lhk lsr";
}
