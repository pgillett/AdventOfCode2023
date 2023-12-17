using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day17Test
{
    private Day17 _day17;

    [TestInitialize]
    public void Setup()
    {
        _day17 = new Day17();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe102()
    {
        var expectedResult = 102;
    
        var actualResult = _day17.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe722()
    {
        var expectedResult = 722;
    
        var actualResult = _day17.Part1(InputData.Day17);
    
        actualResult.Should().Be(expectedResult);
    }
    
    
    [TestMethod]
    public void TestDataPart2ShouldBe94()
    {
        var expectedResult = 94;
    
        var actualResult = _day17.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestData2Part2ShouldBe71()
    {
        var expectedResult = 71;
    
        var actualResult = _day17.Part2(_test2);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe894()
    {
        var expectedResult = 894;
    
        var actualResult = _day17.Part2(InputData.Day17);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"2413432311323
3215453535623
3255245654254
3446585845452
4546657867536
1438598798454
4457876987766
3637877979653
4654967986887
4564679986453
1224686865563
2546548887735
4322674655533";

    private string _test2 = @"111111111111
999999999991
999999999991
999999999991
999999999991";
}
