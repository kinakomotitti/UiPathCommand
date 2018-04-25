using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUiPath.Config;
using KUiPath.Manager;
using KUiPath.Models;
using KUiPath.Util;

namespace KUiPath.Commands
{
    /// <summary>
    /// For Command Option
    /// </summary>
    public class OrchestratorCommand : ICommand
    {
        #region public

        /// <summary>
        /// Initialize Command Option's Model
        /// </summary>
        public ICommandModel CreateCommandModel()
        {
            var model = new OrchestartorModel();
            System.Configuration.AppSettingsReader reader = new System.Configuration.AppSettingsReader();

            model.HostName = string.IsNullOrEmpty(OrchestratorConfig.HostName) ?
                                reader.GetValue(nameof(OrchestratorConfig.HostName), typeof(string)).ToString() :
                                OrchestratorConfig.HostName;

            model.Password = string.IsNullOrEmpty(OrchestratorConfig.Password) ?
                                reader.GetValue(nameof(OrchestratorConfig.Password), typeof(string)).ToString() :
                                OrchestratorConfig.Password;

            model.TenantName = string.IsNullOrEmpty(OrchestratorConfig.TenantName) ?
                                reader.GetValue(nameof(OrchestratorConfig.TenantName), typeof(string)).ToString() :
                                OrchestratorConfig.TenantName;

            model.UserId = string.IsNullOrEmpty(OrchestratorConfig.UserId) ?
                                reader.GetValue(nameof(OrchestratorConfig.UserId), typeof(string)).ToString() :
                                OrchestratorConfig.HostName;

            model.Commands = OrchestratorConfig.Commands;
            return model;
        }

        /// <summary>
        /// Execute Orchestrator api.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FlagManager.ProcessStatus ExecuteCommand(ICommandModel model)
        {
            return this.ExecuteCommandCore(model as OrchestartorModel);
        }

        #endregion

        #region private

        private FlagManager.ProcessStatus ExecuteCommandCore(OrchestartorModel model)
        {
            if (!this.ExecuteAuthenticate(model))
            {
                CommandManager.ResultList.Add("authResult","Loginに失敗しました。");
                return FlagManager.ProcessStatus.Error;
            }

            foreach (var command in model.Commands)
            {
                switch (command)
                {
                    case "Release":
                        this.ExecuteGetReleaseDto(model);
                        break;

                    case "Jobs":
                        this.ExecuteGetJobsDto(model);
                        break;

                    case "Environments":
                        this.ExecuteGetEnvironmentsDto(model);
                        break;

                    case "Settings":
                        this.ExecuteGetSettingsDto(model);
                        break;

                    case "Robots":
                        this.ExecuteGetRobotsDto(model);
                        break;

                    default:
                        break;
                }
            }

            return FlagManager.ProcessStatus.Success;
        }

        #region Commands

        #region Authenticate

        private bool ExecuteAuthenticate(OrchestartorModel model)
        {
            var contents = new OrcAuthenticationModel()
            {
                password = model.Password,
                tenancyName = model.TenantName,
                usernameOrEmailAddress = model.UserId
            };
            string url = $"https://{model.HostName}/api/account/authenticate";
            var task = HttpClientManager.ExecutePostAsync<OrcAuthenticationModel>(url, contents);
            ConsoleUtil.PrintLoadingString<OrcAuthenticationModel>(task);

            HttpClientManager.BearerValue = task.Result.result;
            return task.Result.success;
        }

        #endregion

        #region ReleaseDto

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private void ExecuteGetReleaseDto(OrchestartorModel model)
        {
            string url = $"https://{model.HostName}/odata/Releases";
            var task = HttpClientManager.ExecuteGetAsync<OrcReleaseDtoModel>(url);
            ConsoleUtil.PrintLoadingString<OrcReleaseDtoModel>(task);

            foreach (var item in task.Result.value)
            {
                CommandManager.ResultList.Add(DateTime.Now.ToString("ddss.ffffff").ToString(), $"{item.Name},{item.Key},{item.ProcessVersion}");
                System.Threading.Thread.Sleep(100);
            }

            ConsoleUtil.PrintTable<OrcReleaseDtoModel.Value>(task.Result.value.ToList(), new List<string>() { "Name", "Key", "ProcessVersion" });
            CommandManager.ResultList = new Dictionary<string, string>();
        }

        #endregion

        #region SettingsDto

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private  void ExecuteGetSettingsDto(OrchestartorModel model)
        {
            string url = $"https://{model.HostName}/odata/Settings";
            var task =  HttpClientManager.ExecuteGetAsync<OrcSettingsDto>(url);
            ConsoleUtil.PrintLoadingString<OrcSettingsDto>(task);

            foreach (var item in task.Result.value)
            {
                CommandManager.ResultList.Add(DateTime.Now.ToString("ddss.ffffff").ToString(), $"{item.Id},{item.Name},{item.Value}");
                System.Threading.Thread.Sleep(100);
            }

            ConsoleUtil.PrintTable<OrcSettingsDto.Setting>(task.Result.value.ToList(),
                                                            new List<string>()
                                                            {
                                                                nameof(OrcSettingsDto.Setting.Id),
                                                                nameof(OrcSettingsDto.Setting.Name),
                                                                nameof(OrcSettingsDto.Setting.Value)
                                                            });
            CommandManager.ResultList = new Dictionary<string, string>();
        }

        #endregion

        #region RobotsDto

        private void ExecuteGetRobotsDto(OrchestartorModel model)
        {
            string url = $"https://{model.HostName}/odata/Robots";
            var task = HttpClientManager.ExecuteGetAsync<OrcRobotDto>(url);
            ConsoleUtil.PrintLoadingString<OrcRobotDto>(task);

            foreach (var item in task.Result.value)
            {
                CommandManager.ResultList.Add(DateTime.Now.ToString("ddss.ffffff").ToString(),
                                              $"{item.Id},{item.Name},{item.MachineName},{item.Password},{item.RobotEnvironments},{item.Username}");
                System.Threading.Thread.Sleep(100);
            }


            ConsoleUtil.PrintTable<OrcRobotDto.Value>(task.Result.value.ToList(),
                                                            new List<string>()
                                                            {
                                                                nameof(OrcRobotDto.Value.Id),
                                                                nameof(OrcRobotDto.Value.Name),
                                                                nameof(OrcRobotDto.Value.MachineName),
                                                                nameof(OrcRobotDto.Value.Password),
                                                                nameof(OrcRobotDto.Value.RobotEnvironments),
                                                                nameof(OrcRobotDto.Value.Username)
                                                            });
            CommandManager.ResultList = new Dictionary<string, string>();
        }

        #endregion

        #region EnvironmentsDto

        private void ExecuteGetEnvironmentsDto(OrchestartorModel model)
        {
            string url = $"https://{model.HostName}/odata/Environments";
            var task = HttpClientManager.ExecuteGetAsync<OrcEnvironmentsDto>(url);
            ConsoleUtil.PrintLoadingString<OrcEnvironmentsDto>(task);

            foreach (var item in task.Result.value)
            {
                CommandManager.ResultList.Add(DateTime.Now.ToString("ddss.ffffff").ToString(),
                                              $"{item.Id},{item.Name},{string.Join(",",item.Description)},{item.Robots}");
                System.Threading.Thread.Sleep(100);
            }


            ConsoleUtil.PrintTable<OrcEnvironmentsDto.Value>(task.Result.value.ToList(),
                                                            new List<string>()
                                                            {
                                                                nameof(OrcEnvironmentsDto.Value.Id),
                                                                nameof(OrcEnvironmentsDto.Value.Name),
                                                                nameof(OrcEnvironmentsDto.Value.Description)
                                                            });
            CommandManager.ResultList = new Dictionary<string, string>();
        }

        #endregion

        #region JobsDto

        private void ExecuteGetJobsDto(OrchestartorModel model)
        {
            string url = $"https://{model.HostName}/odata/Jobs";
            var task = HttpClientManager.ExecuteGetAsync<OrcJobsDto>(url);
            ConsoleUtil.PrintLoadingString<OrcJobsDto>(task);

            foreach (var item in task.Result.value)
            {
                CommandManager.ResultList.Add(DateTime.Now.ToString("ddss.ffffff").ToString(),
                                              $"{item.Id},{item.Key},{item.Source},{item.Info},{item.StartTime}");
                System.Threading.Thread.Sleep(100);
            }


            ConsoleUtil.PrintTable<OrcJobsDto.Value>(task.Result.value.ToList(),
                                                            new List<string>()
                                                            {
                                                                nameof(OrcJobsDto.Value.Id),
                                                                nameof(OrcJobsDto.Value.Key),
                                                                nameof(OrcJobsDto.Value.Source),
                                                                nameof(OrcJobsDto.Value.Info),
                                                                nameof(OrcJobsDto.Value.StartTime)
                                                            });
            CommandManager.ResultList = new Dictionary<string, string>();
        }

        #endregion

        #endregion

        #endregion
    }
}
