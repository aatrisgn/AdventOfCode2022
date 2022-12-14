using TGC.AdventOfCode2022.Abstractions;

namespace TGC.AdventOfCode2022.Runner.Runners;

public class Runner02 : IRunner
{
    private static Dictionary<string, int> scoreMatching = new Dictionary<string, int>()
    {
        /*{"A Z", 3},
        {"A X", 4},
        {"A Y", 8},
        {"B Z", 9},
        {"B X" , 1},
        {"B Y", 5},
        {"C Z", 6},
        {"C X", 7},
        {"C Y", 2}*/

        {"A Z", 8}, //Rock vs. Paper - Win
        {"A X", 3}, //Rock vs. Scissors - Lose
        {"A Y", 4}, //Rock vs. Rock - Draw
        {"B Z", 9}, //Paper vs. Scissors - Win
        {"B X" , 1}, //Paper vs. rock - Lose
        {"B Y", 5}, //Paper vs. paper - Draw
        {"C Z", 7}, //Scissor vs. rock - Win
        {"C X", 2}, //Scissor vs. paper - Lose
        {"C Y", 6} //Scissor vs. scissor - Draw
    };

    /*
     * A: rock
     * B: Paper
     * C: scissors
     * 
     * X: Rock // Lose
     * Y: Paper // Draw
     * Z: Scissors // Win
     * 
     * Rock: 1
     * Paper: 2
     * Scissor: 3
     * 
     * WIN: 6
     * DRAW: 3
     * Loss: 0
     * */

    private object _lock = new object();

    public bool Accept(int number)
    {
        return number == 2;
    }

    public async Task RunAsync()
    {
        var pointCounter = 0;
        var content = await File.ReadAllTextAsync("DataFiles/input02.txt");
        var splittedContent = content.Split("\n");

        Parallel.ForEach(splittedContent, (line) =>
        {
            var score = scoreMatching.First(s => s.Key == line.Trim()).Value;

            lock (_lock)
            {
                pointCounter += score;
            }

        });

        Console.WriteLine("Total score: " + pointCounter);
    }
}