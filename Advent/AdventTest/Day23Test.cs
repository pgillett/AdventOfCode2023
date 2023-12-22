using System;
using System.Collections.Generic;
using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class Day23Test
{
    private Day23 _day23;

    [TestInitialize]
    public void Setup()
    {
        _day23 = new Day23();
    }

    [TestMethod]
    public void TestDataPart1ShouldBe94()
    {
        var expectedResult = 94;
    
        var actualResult = _day23.Part1(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart1ShouldBe2106()
    {
        var expectedResult = 2106;
    
        var actualResult = _day23.Part1(InputData.Day23);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void TestDataPart2ShouldBe154()
    {
        var expectedResult = 154;
    
        var actualResult = _day23.Part2(_test);
    
        actualResult.Should().Be(expectedResult);
    }
    
    [TestMethod]
    public void RealDataPart2ShouldBe6350()
    {
        var expectedResult = 6350;
    
        var actualResult = _day23.Part2(InputData.Day23);
    
        actualResult.Should().Be(expectedResult);
    }

    private string _test = @"#.#####################
#.......#########...###
#######.#########.#.###
###.....#.>.>.###.#.###
###v#####.#v#.###.#.###
###.>...#.#.#.....#...#
###v###.#.#.#########.#
###...#.#.#.......#...#
#####.#.#.#######.#.###
#.....#.#.#.......#...#
#.#####.#.#.#########v#
#.#...#...#...###...>.#
#.#.#v#######v###.###v#
#...#.>.#...>.>.#.###.#
#####v#.#.###v#.#.###.#
#.....#...#...#.#.#...#
#.#########.###.#.#.###
#...###...#...#...#.###
###.###.#.###v#####v###
#...#...#.#.>.>.#.>.###
#.###.###.#.###.#.#v###
#.....###...###...#...#
#####################.#";
}
