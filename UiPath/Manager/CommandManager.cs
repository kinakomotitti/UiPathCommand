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
        private static Dictionary<string, ICommand> _options = new Dictionary<string, ICommand>();
        public static Dictionary<string, string> ResultList { get; set; } = new Dictionary<string, string>();

        public static FlagManager.ProcessStatus DispatchCommand()
        {
            try
            {
                foreach (var item in CommandManager._options)
                {
                    var model = item.Value.CreateCommandModel(CommandManager._options);
                    item.Value.ExecuteCommand(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().ToString());
                return FlagManager.ProcessStatus.Error;
            }
            return FlagManager.ProcessStatus.Success;
        }

        public static FlagManager.ProcessStatus OptionAnalistic(string[] args)
        {
            try
            {
                if (CommandManager.ArgsFormatCheck(args) == false) return FlagManager.ProcessStatus.Error;

                CommandManager.ArgsToCommandList(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().ToString());
                return FlagManager.ProcessStatus.Error;
            }
            return FlagManager.ProcessStatus.Success;
        }

        public static FlagManager.ProcessStatus DisplayCommandResult()
        {
            try
            {
                foreach (var item in CommandManager.ResultList)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().ToString());
                return FlagManager.ProcessStatus.Error;
            }

            return FlagManager.ProcessStatus.Success;
        }

        #region OptionAnalistic

        private static bool ArgsFormatCheck(string[] args)
        {
            if (args == null) return false;
            if (args.Length > 1) return false;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains("-") == false && args[i].Contains("--") == false)
                {
                    return false;
                }
                //forward / backward
                string current = args[i].Replace("-", "").Substring(0, 1);
                if (current == "v" || current == "?" || current == "i")
                {
                    //後ろに引数がないオプションの場合はスキップ
                    continue;
                }

                string backward = args[i + 1].Remove('=').Substring(0, 1);
                if (backward == current)
                {
                    return false;
                }
            }
            return true;
        }

        private static void ArgsToCommandList(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                int next = i + 1;
                switch (args[i].Replace("-", "").Substring(0, 1))
                {
                    case "v":
                        var opstion = new VersionCommand();
                        _options.Add("v", opstion);
                        break;
                    case "i":
                        break;
                    case "?":
                        break;
                    case "f":
                        break;
                    case "h":
                        break;
                    case "U":
                        break;
                    case "W":
                        break;
                    case "T":
                        break;
                    case "C":
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
    }
}
