using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KUiPath.Manager;
using KUiPath.Models;

namespace KUiPath.Commands
{
    public class VersionCommand : ICommand
    {
        public ICommandModel CreateCommandModel()
        {
            return new EmptyCommandModel();
        }

        /// <summary>
        /// show uiPathCommand version information.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public FlagManager.ProcessStatus ExecuteCommand(ICommandModel model)
        {
            var internalModel = model as EmptyCommandModel;
            if (internalModel == null) return FlagManager.ProcessStatus.Error;

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            CommandManager.ResultList.Add(nameof(VersionCommand),$"KUiPath command {version}");

            return FlagManager.ProcessStatus.Success;
        }

    }
}
