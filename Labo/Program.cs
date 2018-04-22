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
            PrintLoadingString(test);
        }

        private static string[] DefaultPattern = new string[]
        {
            " ●    ",
            "  ●   ",
            "   ●  ",
            "    ● ",
            "     ●",
            "    ● ",
            "   ●  ",
            "  ●   ",
            " ●    ",
            "●     "
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="pattern"></param>
        public static void PrintLoadingString(Task task, string[] pattern=null)
        {
            pattern = pattern ?? DefaultPattern;

            while (!task.IsCompleted)
            {
                Console.CursorVisible = false;

                foreach (var item in pattern)
                {
                    Console.Write(item);
                    Console.SetCursorPosition(0, Console.CursorTop);
                    System.Threading.Thread.Sleep(100);
                }
                Console.Write(new string(' ', pattern.Max().Length));
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.CursorVisible = true;
            }
        }
    }
}
