using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.AdventOfCode2022.Runner.Runners;
using Xunit;

namespace TGC.AdventOfCode2022.Tests
{
    public class Runner04Tests
    {
        [Fact]
        public void DuplicateSectionCount_Is2()
        {
            var runner = new Runner04();
            var result = runner.firstTask("TestInput04.txt").Result;
            result.Should().Be(2);
        }

        [Fact]
        public void DuplicateSectionCount_Is4()
        {
            var runner = new Runner04();
            var result = runner.secondTask("TestInput04.txt").Result;
            result.Should().Be(4);
        }

        [Fact]
        public void Test01()
        {
            var runner = new Runner04();
            var hasSectionOverlap = runner.sectionsHasOverlap("7-57,8-16");
            hasSectionOverlap.Should().BeTrue();
        }

        [Fact]
        public void Test02()
        {
            var runner = new Runner04();
            var hasSectionOverlap = runner.sectionsHasOverlap("35-48,35-70");
            hasSectionOverlap.Should().BeTrue();
        }

        [Fact]
        public void Test03()
        {
            var runner = new Runner04();
            var hasSectionOverlap = runner.sectionsHasOverlap("73-87,19-72");
            hasSectionOverlap.Should().BeFalse();
        }

        [Fact]
        public void Test04()
        {
            var runner = new Runner04();
            var hasSectionOverlap = runner.sectionsHasOverlap("14-87,15-72");
            hasSectionOverlap.Should().BeTrue();
        }

        [Fact]
        public void Test05()
        {
            var runner = new Runner04();
            var hasSectionOverlap = runner.sectionsHasOverlap("15-72,14-87");
            hasSectionOverlap.Should().BeTrue();
        }

        [Fact]
        public void Test06()
        {
            var runner = new Runner04();
            var hasSectionOverlap = runner.sectionsHasOverlap("19-72,19-72");
            hasSectionOverlap.Should().BeTrue();
        }
    }
}
