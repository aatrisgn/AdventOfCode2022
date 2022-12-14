using FluentAssertions;
using TGC.AdventOfCode2022.Runner.Runners;
using Xunit;

namespace TGC.AdventOfCode2022.Tests;

public class Runner07Tests
{
    [Fact]
    public void FirstTask_WithTestData_Return95437()
    {
        var runner = new Runner07();
        var result = runner.FirstTask("TestInputFiles/07/TestInput-1.txt");
        result.Should().Be(95437);
    }
}
