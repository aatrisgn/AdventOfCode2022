using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.AdventOfCode2022.Abstractions;

namespace TGC.AdventOfCode2022.Runner.Runners;

public class Runner07 : IRunner
{
    public bool Accept(int number)
    {
        return number == 7;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("Result for Task 1: " + await FirstTask("DataFiles/Input07.txt"));
    }

    public async Task<int> FirstTask(string inputFile)
    {

        return 0;
    }
}
