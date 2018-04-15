using KUiPath.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath
{
    /// <summary>
    /// UiPath Command Entry Point
    /// </summary>
    public class Program
    {
        public static int Main(string[] args)
        {
            Program instance = new Program();
            var result= instance.MainProrocess(args);
#if DEBUG 
            Console.ReadKey();
#endif
            return result;

        }

        private int MainProrocess(string[] args)
        {
            int errorLevel = 9;
            //comannd analysis

            //main process execute
            CommandManager.DispatchCommand();

            //show result

            //return %ErrorLevel%
            return errorLevel;
        }
    }
}
