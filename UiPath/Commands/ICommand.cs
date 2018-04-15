using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Execute supecific Command.
        /// Mainly,Call WEB API that is specified by argument.
        /// </summary>
        /// <param name="args">Command arguments</param>
        /// <returns></returns>
        int ExecuteCommand(List<string> args);
    }
}
