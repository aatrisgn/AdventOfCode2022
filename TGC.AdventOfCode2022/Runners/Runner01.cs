using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.AdventOfCode2022.Abstractions;

namespace TGC.AdventOfCode2022.Runner.Runners;

public class Runner01 : IRunner
{
    public bool Accept(int number)
    {
        return number == 1;
    }

    public async Task RunAsync()
    {
        var listOfSums = new List<int>();
        var content2 = await File.ReadAllTextAsync("DataFiles/Input01.txt");
        var splittedContent = content2.Split("\r\n\r\n");

        Parallel.ForEach(splittedContent, i => {
            var splittedNumbers = i.Split("\n");
            var summedValue = splittedNumbers.Sum(number => int.Parse(number));
            listOfSums.Add(summedValue);
        });

        var orderedListOfSums = listOfSums.OrderByDescending(s => s);

        var topThreeCalories = orderedListOfSums.Take(3).Sum();

        Console.WriteLine("Elf with most calories: "+ orderedListOfSums.First());
        Console.WriteLine("Elf with second most calories: " + orderedListOfSums.Skip(1).First());
        Console.WriteLine("Elf with third most calories: " + orderedListOfSums.Skip(2).First());

        Console.WriteLine("Total: " + topThreeCalories);
    }
}
