namespace TGC.AdventOfCode2022.Runners.Extensions;

public static class StackExtensions
{
    public static void Add(this Stack<string> stack, string value)
    {
        stack.Push(value);
    }
}
