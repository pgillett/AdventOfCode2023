using System;
using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest;

[TestClass]
public class ParsingTest
{
    [TestMethod]
    [DataRow("123",123)]
//    [DataRow("123456789", 123456789)]
    public void SelfIntParseSmall(string input, int expected)
    {
        Parsing.Int(input.AsSpan()).Should().Be(expected);
    }
    
}