using System.Linq;
using System.Text.RegularExpressions;
using TGC.AdventOfCode2022.Abstractions;

namespace TGC.AdventOfCode2022.Runner.Runners
{
    public class Runner04 : IRunner
    {
        private object _lock = new object();
        private const string regexPattern = @"\d+";

        public bool Accept(int number)
        {
            return number == 4;
        }

        public async Task RunAsync()
        {
            var firstTaskResult = await firstTask("DataFiles/Input04.txt");
            Console.WriteLine("First task is: " + firstTaskResult);
            var secondTaskResult = await secondTask("DataFiles/Input04.txt");
            Console.WriteLine("First task is: " + secondTaskResult);
        }

        public async Task<int> firstTask(string inputFile)
        {
            var content = await File.ReadAllLinesAsync(inputFile);
            var overlapCount = 0;

            Parallel.ForEach(content, (line) =>
            {
                if (sectionsHasOverlap(line))
                {
                    lock (_lock)
                    {
                        overlapCount++;
                    }
                }
            });

            return overlapCount;
        }

        public async Task<int> secondTask(string inputFile)
        {
            var content = await File.ReadAllLinesAsync(inputFile);
            var overlapCount = 0;

            Parallel.ForEach(content, (line) =>
            {
                if (sectionsHasTotalOverlap(line))
                {
                    lock (_lock)
                    {
                        overlapCount++;
                    }
                }
            });

            return overlapCount;
        }

        public bool sectionsHasOverlap(string input)
        {
            var r = new Regex(regexPattern, RegexOptions.IgnoreCase);
            var match = r.Matches(input);

            if (match.Any())
            {
                if(int.Parse(match[0].Value) == int.Parse(match[2].Value))
                {
                    return true;
                }

                if (int.Parse(match[0].Value) <= int.Parse(match[2].Value)) // 3 vs 2
                {
                    if(int.Parse(match[1].Value) >= int.Parse(match[3].Value)) //7 vs 9
                    {
                        return true;
                    }
                }
                else
                {
                    if (int.Parse(match[1].Value) <= int.Parse(match[3].Value)) //3-32 ,2-5
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool sectionsHasTotalOverlap(string input)
        {
            var r = new Regex(regexPattern, RegexOptions.IgnoreCase);
            var match = r.Matches(input);

            if (match.Any())
            {
                if (int.Parse(match[0].Value) == int.Parse(match[2].Value))
                {
                    return true;
                }

                if (int.Parse(match[1].Value) == int.Parse(match[3].Value))
                {
                    return true;
                }

                if (int.Parse(match[0].Value) < int.Parse(match[2].Value))
                {
                    if (int.Parse(match[1].Value) >= int.Parse(match[2].Value))
                    {
                        return true;
                    }
                }
                else
                {
                    if (int.Parse(match[0].Value) <= int.Parse(match[3].Value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}