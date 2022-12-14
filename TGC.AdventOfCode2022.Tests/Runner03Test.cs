using FluentAssertions;
using TGC.AdventOfCode2022._03;
using Xunit;

namespace TGC.AdventOfCode2022.Tests
{
    public class Runner03Test
    {
        [Fact]
        public void BadgeGrouping_is70()
        {
            var runner = new Runner03();
            var result = runner.secondTask("TestInput03.txt").Result;
            result.Should().Be(70);
        }
    }
}