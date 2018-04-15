using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Commands
{
    class VersionCommand : ICommand
    {
        /// <summary>
        /// show uiPathCommand version information.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public int ExecuteCommand(List<string> args)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine($"KUiPath command {version}");
            return 0;
        }
       
    }
}
