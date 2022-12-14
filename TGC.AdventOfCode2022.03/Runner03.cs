using System.Collections.Concurrent;
using TGC.AdventOfCode2022.Abstractions;

namespace TGC.AdventOfCode2022._03
{
    public class Runner03 : IRunner
    {
        public bool Accept(int number)
        {
            return number == 3;
        }

        private object _lock = new object();
        private object _lockDequeue = new object();
        private string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private char[] letterArray;

        public async Task RunAsync()
        {
            await secondTask("Input03.txt");
        }

        public async Task<int> secondTask(string inputFile)
        {
            letterArray = letters.ToArray();
            var prioritySum = 0;
            
            var content = await File.ReadAllTextAsync(inputFile);
            var concurrentQueue = new ConcurrentQueue<string>(content.Split("\n"));

            int concurrentSize = concurrentQueue.Count;

            var taskList = new List<Task>();

            for (int i = 0; i < concurrentSize / 3; i++)
            {
                taskList.Add(Task.Factory.StartNew(() =>
                {
                    List<string> items = new List<string>();
                    lock (_lockDequeue)
                    {
                        items.AddRange(concurrentQueue.DequeueChunk(3));
                    }

                    var firstSentence = items.First().Trim();
                    var secondSentence = items.Skip(1).First().Trim();
                    var thirdSentence = items.Skip(2).First().Trim();

                    var firstSentenceLetters = firstSentence.ToArray();

                    foreach (var letter in firstSentenceLetters)
                    {
                        if (secondSentence.Contains(letter) && thirdSentence.Contains(letter))
                        {
                            var indexCount = letters.IndexOf(letter);
                            lock (_lock)
                            {
                                prioritySum = prioritySum + (indexCount + 1);
                            }
                            break;
                        }
                    }
                }));
            }

            Task.WaitAll(taskList.ToArray());

            Console.WriteLine("Result is: "+ prioritySum);
            return prioritySum;
        }

        private async Task firstTask()
        {
            letterArray = letters.ToArray();

            var prioritySum = 0;
            var content = await File.ReadAllLinesAsync("Input03.txt");

            Parallel.ForEach(content, (line) =>
            {
                var wordLenght = line.Length / 2;
                var wordOne = line.Substring(0, wordLenght).ToArray();
                var wordTwo = line.Substring(wordLenght);

                foreach (var letter in wordOne)
                {
                    if (wordTwo.Contains(letter))
                    {
                        var indexCount = letters.IndexOf(letter);
                        lock (_lock)
                        {
                            prioritySum += (indexCount + 1);
                        }
                        break;
                    }
                }
            });

            Console.WriteLine("Total is: " + prioritySum);
        }
    }
}