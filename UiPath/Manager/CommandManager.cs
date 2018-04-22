using KUiPath.Commands;
using KUiPath.Config;
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
                    var model = item.Value.CreateCommandModel();
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

        /// <summary>
        /// オプション引数の検証を行います。
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static FlagManager.ProcessStatus OptionAnalistic(string[] args)
        {
            try
            {
                if (CommandManager.ArgsFormatCheck(args) == false) args = new string[] { "-i" };

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
                    Console.WriteLine(item.Value);
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

        /// <summary>
        /// オプション引数の入力チェック
        /// チェックに失敗した場合は呼び出し元にFalseを返却する
        /// </summary>
        /// <param name="args">オプション引数</param>
        /// <returns></returns>
        private static bool ArgsFormatCheck(string[] args)
        {
            //引数がない場合はfalse
            if (args == null) return false;
            if (args.Length < 1) return false;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains("-") == false && args[i].Contains("--") == false)
                {
                    //usageに従っていない形式のオプション引数はfalse
                    return false;
                }
                
                string current = args[i].Replace("-", "").Substring(0, 1);
                if (current == "v" || current == "?" || current == "i")
                {
                    //後ろに引数がないオプションの場合はスキップ
                    continue;
                }

                //オプション引数のパラメータが指定されていない場合false
                if (args.Length == i-1) return false;

                string next = args[i + 1].Split().First();
                //オプション引数のパラメータがハイフンから始まっていたらfalse
                if (next.Equals("-")) return false;

                //後ろにオプション引数のパラメータがあるため、次のオプションの検査へ移る
                i++;
            }
            return true;
        }

        private static void ArgsToCommandList(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                int next = i + 1;
                ICommand option;
                switch (args[i].Replace("-", "").Substring(0, 1))
                {
                    case "v":
                        option = new VersionCommand();
                        if(_options.ContainsKey("v")==false) _options.Add("v", option);
                        break;
                    case "i":
                        option = new InformationCommand();
                        if (_options.ContainsKey("i") == false) _options.Add("i", option);
                        break;
                    case "?":
                        option = new InformationCommand();
                        if (_options.ContainsKey("i") == false) _options.Add("i", option);
                        break;
                    case "h":
                        if (args[i] == "--help")
                        {
                            option = new InformationCommand();
                            if (_options.ContainsKey("i") == false) _options.Add("i", option);
                        }
                        else if (args[i] == "-hostname" || args[i].Split('=')[0] == "--host")
                        {
                            OrchestratorConfig.HostName = args[next];
                        }
                        break;
                    case "H":
                        OrchestratorConfig.HostName = args[next];
                        break;
                    case "f":
                        break;
                    case "U":
                        OrchestratorConfig.UserId = args[next];
                        break;
                    case "W":
                        OrchestratorConfig.Password = args[next];
                        break;
                    case "T":
                        OrchestratorConfig.TenantName = args[next];
                        break;
                    case "C":
                        OrchestratorConfig.Commands = args[next].Split(',').ToList<string>();
                        option = new OrchestratorCommand();
                        if (_options.ContainsKey("c") == false) _options.Add("c", option);
                        break;
                    default:
                        break;
                }
            }

            if (CommandManager._options.Count == 0 ||
                CommandManager._options.ContainsKey("i"))
                CommandManager._options = new Dictionary<string, ICommand>() { {"i", new InformationCommand()} };

            else if (CommandManager._options.ContainsKey("v"))
                CommandManager._options = new Dictionary<string, ICommand>() { { "v", new VersionCommand() } };

        }
        #endregion
    }
}
