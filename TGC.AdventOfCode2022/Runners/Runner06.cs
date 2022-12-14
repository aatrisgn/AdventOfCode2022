using TGC.AdventOfCode2022.Abstractions;

namespace TGC.AdventOfCode2022.Runner.Runners;

public class Runner06 : IRunner
{
    public bool Accept(int number)
    {
        return number == 6;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("Result for Task 1: " + await FirstTask("DataFiles/Input06.txt"));
        Console.WriteLine("Result for Task 2: " + await SecondTask("DataFiles/Input06.txt"));
    }

    public async Task<int> FirstTask(string inputFile)
    {
        return await locateMessageMarker(inputFile, 4);
    }

    public async Task<int> SecondTask(string inputFile)
    {
        return await locateMessageMarker(inputFile, 14);
    }

    private async Task<int> locateMessageMarker(string inputFile, int uniqueCount)
    {
        var content = await File.ReadAllTextAsync(inputFile);
        var characterArray = content.ToCharArray();
        int letterCounter = 0;

        for (var i = 0; i < characterArray.Length - uniqueCount; i++)
        {
            var splicedCharacters = characterArray.Skip(i).Take(uniqueCount);
            if (splicedCharacters.Distinct().Count() == splicedCharacters.Count())
            {
                letterCounter += uniqueCount;
                break;
            }
            letterCounter++;
        }

        return letterCounter;
    }
}
