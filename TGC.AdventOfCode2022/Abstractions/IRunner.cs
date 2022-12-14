using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGC.AdventOfCode2022.Abstractions
{
    public interface IRunner
    {
        bool Accept(int number);
        Task RunAsync();
    }
}
