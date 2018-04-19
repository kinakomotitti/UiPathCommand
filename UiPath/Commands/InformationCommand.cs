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
            infoBuilder.AppendLine($"{new string(' ', 15)}[-f / --file = fileName]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-hostname / --host = host name]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-U / --username = user name]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-W / --password = password]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-T / --tenantname = tenantn ame]");
            infoBuilder.AppendLine($"{new string(' ', 15)}[-C / --command = command name]");

            CommandManager.ResultList.Add(nameof(InformationCommand), infoBuilder.ToString());
            return FlagManager.ProcessStatus.Success;
        }
    }
}
