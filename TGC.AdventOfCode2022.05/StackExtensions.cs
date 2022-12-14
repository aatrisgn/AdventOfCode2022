using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGC.AdventOfCode2022._05
{
    public static class StackExtensions
    {
        public static void Add(this Stack<string> stack, string value)
        {
            stack.Push(value);
        }
    }
}
