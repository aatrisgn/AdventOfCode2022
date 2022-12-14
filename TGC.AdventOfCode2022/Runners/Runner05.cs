using TGC.AdventOfCode2022.Abstractions;
using System.Text.RegularExpressions;
using TGC.AdventOfCode2022.Runners.Extensions;

namespace TGC.AdventOfCode2022.Runner.Runners;

public class Runner05 : IRunner
{
    private string regexPattern = @"\d+";
    private Stack<string>[] CargoStackData = new Stack<string>[]
    {
        new Stack<string>(){"R", "G", "H", "Q", "S", "B", "T", "N"},
        new Stack<string>(){"H", "S", "F", "D", "P", "Z", "J"},
        new Stack<string>(){"Z", "H", "V"},
        new Stack<string>(){"M", "Z", "J", "F", "G", "H"},
        new Stack<string>(){"T", "Z", "C", "D", "L", "M", "S", "R"},
        new Stack<string>(){"M", "T", "W", "V", "H", "Z", "J"},
        new Stack<string>(){"T","F","P","L","Z"},
        new Stack<string>(){"Q","V","W","S"},
        new Stack<string>(){"W","H","L","M","T","D","N","C"},
    };

    public bool Accept(int number)
    {
        return number == 5;
    }

    public async Task RunAsync()
    {
        await SecondTask("DataFiles/Input05.txt");
    }

    public async Task<int> FirstTask(string inputFile)
    {
        var content = await File.ReadAllLinesAsync(inputFile);

        foreach(var line in content)
        {
            var r = new Regex(regexPattern, RegexOptions.IgnoreCase);
            var match = r.Matches(line);

            for (int i = 0; i < int.Parse(match[0].Value); i++)
            {
                var cargoBox = CargoStackData[int.Parse(match[1].Value)-1].Pop();
                CargoStackData[int.Parse(match[2].Value)-1].Push(cargoBox);
            }
        }

        CargoStackData.ToList().ForEach(c => Console.WriteLine(c.First()));
        return 0;
    }

    public async Task<int> SecondTask(string inputFile)
    {
        var content = await File.ReadAllLinesAsync(inputFile);

        foreach (var line in content)
        {
            var r = new Regex(regexPattern, RegexOptions.IgnoreCase);
            var match = r.Matches(line);

            var tempCargoStorage = new Stack<string>();

            for (int i = 0; i < int.Parse(match[0].Value); i++)
            {
                var cargoBox = CargoStackData[int.Parse(match[1].Value) - 1].Pop();
                tempCargoStorage.Push(cargoBox);
            }

            foreach( var cargoBox in tempCargoStorage)
            {
                CargoStackData[int.Parse(match[2].Value) - 1].Push(cargoBox);
            }
        }

        CargoStackData.ToList().ForEach(c => Console.WriteLine(c.First()));

        return 0;
    }
}