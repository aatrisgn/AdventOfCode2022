using FluentAssertions;
using TGC.AdventOfCode2022.Runner.Runners;
using Xunit;

namespace TGC.AdventOfCode2022.Tests;

public class Runner06Tests
{
    [Fact]
    public void FirstExampleTest()
    {
        var runner = new Runner06();
        var result = runner.FirstTask("TestInputFiles/06/TestInput06-1.txt").Result;
        result.Should().Be(5);
    }

    [Fact]
    public void SecondExampleTest()
    {
        var runner = new Runner06();
        var result = runner.FirstTask("TestInputFiles/06/TestInput06-2.txt").Result;
        result.Should().Be(6);
    }

    [Fact]
    public void ThirdExampleTest()
    {
        var runner = new Runner06();
        var result = runner.FirstTask("TestInputFiles/06/TestInput06-3.txt").Result;
        result.Should().Be(10);
    }

    [Fact]
    public void FourthExampleTest()
    {
        var runner = new Runner06();
        var result = runner.FirstTask("TestInputFiles/06/TestInput06-4.txt").Result;
        result.Should().Be(11);
    }

    [Fact]
    public void SecondTaskFirstTest()
    {
        var runner = new Runner06();
        var result = runner.SecondTask("TestInputFiles/06/TestInput06-5.txt").Result;
        result.Should().Be(19);
    }
    [Fact]
    public void SecondTaskSecondTest()
    {
        var runner = new Runner06();
        var result = runner.SecondTask("TestInputFiles/06/TestInput06-6.txt").Result;
        result.Should().Be(23);
    }
    [Fact]
    public void SecondTaskThirdTest()
    {
        var runner = new Runner06();
        var result = runner.SecondTask("TestInputFiles/06/TestInput06-7.txt").Result;
        result.Should().Be(23);
    }
    [Fact]
    public void SecondTaskFourthTest()
    {
        var runner = new Runner06();
        var result = runner.SecondTask("TestInputFiles/06/TestInput06-8.txt").Result;
        result.Should().Be(29);
    }
    [Fact]
    public void SecondTaskFifthTest()
    {
        var runner = new Runner06();
        var result = runner.SecondTask("TestInputFiles/06/TestInput06-9.txt").Result;
        result.Should().Be(26);
    }
}