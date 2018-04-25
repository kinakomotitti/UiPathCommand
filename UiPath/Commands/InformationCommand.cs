using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUiPath.Manager;
using KUiPath.Models;

namespace KUiPath.Commands
{
    public class InformationCommand : ICommand
    {
        public ICommandModel CreateCommandModel()
        {
            return new EmptyCommandModel();
        }

        public FlagManager.ProcessStatus ExecuteCommand(ICommandModel model)
        {
            StringBuilder infoBuilder = new StringBuilder();
            infoBuilder.AppendLine("usage: KUiPath [-v / --version]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-i / --info]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-? / --help]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-f fileName]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-H host name]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-U user name]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-W password]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-T tenantn ame]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-C orchestrator API Name]");
            infoBuilder.AppendLine("");
            infoBuilder.AppendLine("Support \"Orchestrator API\" is Authenticate");
            infoBuilder.AppendLine($"{new string(' ', 30)}Settings");
            infoBuilder.AppendLine($"{new string(' ', 30)}Robots");
            infoBuilder.AppendLine($"{new string(' ', 30)}Environments");
            infoBuilder.AppendLine($"{new string(' ', 30)}Jobs");
            infoBuilder.AppendLine($"{new string(' ', 30)}Release");

            CommandManager.ResultList.Add(nameof(InformationCommand), infoBuilder.ToString());
            return FlagManager.ProcessStatus.Success;
        }
    }
}
