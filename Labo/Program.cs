using KUiPath.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Task(() => System.Threading.Thread.Sleep(10000));
            test.Start();
            ConsoleUtil.PrintLoadingString(test);
        }

    }
}
