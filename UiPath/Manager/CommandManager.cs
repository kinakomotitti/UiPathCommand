using KUiPath.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Manager
{
    public static class CommandManager
    {
        public static void DispatchCommand()
        {
            VersionCommand command = new VersionCommand();
            command.ExecuteCommand(new List<string>() { });
        }
    }
}
