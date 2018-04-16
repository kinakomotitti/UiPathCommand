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
            var result = instance.MainProrocess(args);
#if DEBUG 
            Console.ReadKey();
#endif
            return (int)result;

        }

        private FlagManager.ProcessStatus MainProrocess(string[] args)
        {
            FlagManager.ProcessStatus errorLevel = FlagManager.ProcessStatus.Error;
            //comannd analysis
            errorLevel = CommandManager.OptionAnalistic(args);

            //main process execute
            errorLevel = CommandManager.DispatchCommand();

            //show result
            errorLevel = CommandManager.DisplayCommandResult();

            //return %ErrorLevel%
            return errorLevel;
        }
    }
}
