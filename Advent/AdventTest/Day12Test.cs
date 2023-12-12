using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day12Test
{
    private Day12 _day12;

    [TestInitialize]
    public void Setup()
    {
        _day12 = new Day12();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe21()
    {
        var expectedResult = 21;
    
        var actualResult = _day12.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }

    [TestMethod]
    public void RealDataPart1ShouldBe7916()
    {
        var expectedResult = 7916;

        var actualResult = _day12.Part1(InputData.Day12);

        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart1ShouldBe21a()
    {
        var expectedResult = 15;
    
        var actualResult = _day12.Part1("??##??????????.?# 4,4,2");
    
        actualResult.Should().Be(expectedResult);
    }

    [TestMethod]
    public void TestDataPart1ShouldBe21b()
    {
        var expectedResult = 15;
    
        var actualResult = _day12.Part2("????????????##?? 1,1,1,1,3");
        
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    [DataRow("???????? 1,2,3", 1)]
    [DataRow("????????? 1,2,3", 4)] // 3
    [DataRow("?????????? 1,2,3", 10)] // 6
    [DataRow("??????????? 1,2,3", 20)] // 10
    [DataRow("???????????? 1,2,3", 35)] // 15
    [DataRow("????????????? 1,2,3", 56)] // 21
    [DataRow("???????# 1,2,3", 1)]
    [DataRow("????????# 1,2,3", 3)] // 3
    [DataRow("?????????# 1,2,3", 6)] // 6
    [DataRow("??????????# 1,2,3", 10)] // 10
    [DataRow("???????????# 1,2,3", 15)] // 15
    [DataRow("????????????# 1,2,3", 21)] // 21
    [DataRow("???#???? 1,2,3", 1)]
    [DataRow("???#????? 1,2,3", 4)] // 3
    [DataRow("???#?????? 1,2,3", 7)] // 3
    [DataRow("???#??????? 1,2,3", 11)] // 4
    [DataRow("???#???????? 1,2,3", 16)] // 4
    [DataRow("???#????????? 1,2,3", 22)] // 4
    public void TestDataPart1ShouldBe21c(string input, int expectedResult)
    {
        var actualResult = _day12.Part1(input);
        
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe525152()
    {
        var expectedResult = 525152;
    
        var actualResult = _day12.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe525152a()
    {
        var expectedResult = 525152;
    
        // var actualResult = _day12.Part2(InputData.Day12);
        //
        // actualResult.Should().Be(expectedResult);
    }

    private string _test = @"???.### 1,1,3
.??..??...?##. 1,1,3
?#?#?#?#?#?#?#? 1,3,1,6
????.#...#... 4,1,1
????.######..#####. 1,6,5
?###???????? 3,2,1";
}
