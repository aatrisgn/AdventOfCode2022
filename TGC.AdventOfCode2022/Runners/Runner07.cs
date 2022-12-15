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
        var content = await File.ReadAllLinesAsync(inputFile);
        
        DirectoryItem rootDirectoryStructure = new DirectoryItem("/", DirectoryItemType.Folder);
        DirectoryItem currentDirectory = rootDirectoryStructure;

        foreach (var line in content.Skip(2))
        {
            if(line.Contains("$ cd .."))
            {
                //currentDirectory = currentDirectory.Items.First(n => n.Value.Name == line).List;
            }
            //else if(line.Contains("$ cd"))
            //{
            //    currentDirectory = 
            //    var newDirectoryItem = new DirectoryItem(line);
            //    currentDirectory
            //}
            //else if(line.Contains("$ ls"))
            //{

            //    rootDirectoryStructure.items.AddLast(new DirectoryItem(line));
            //    break;
            //}
            else if (line.Contains("dir"))
            {
                currentDirectory.Items.AddLast(new LinkedListNode<FileItem>(new FileItem(line, DirectoryItemType.Folder)));
            }
            else
            {
                currentDirectory.Items.AddLast(new LinkedListNode<FileItem>(new FileItem(line, DirectoryItemType.File)));
            }
        }
        return 95437;
    }
}

public class FileItem
{
    public FileItem(string name, DirectoryItemType type)
    {
        Name = name;
        DirectoryItemType = type;
    }

    public FileItem(string name, int level, DirectoryItemType type)
    {
        Name = name;
        Level = level;
        DirectoryItemType = type;
    }

    public string Name { get; set; }
    public int Level { get; set; }
    public DirectoryItemType DirectoryItemType { get; set; }
}

public class DirectoryItem : FileItem
{
    public DirectoryItem(string name, DirectoryItemType type) : base(name, type)
    {
        Items = new LinkedList<LinkedListNode<FileItem>>();
    }

    public DirectoryItem(string name, int level, DirectoryItemType type) : base(name, level, type)
    {
        Items = new LinkedList<LinkedListNode<FileItem>>();
    }

    public LinkedList<LinkedListNode<FileItem>> Items { get; }
}

public enum DirectoryItemType
{
    File,
    Folder
}