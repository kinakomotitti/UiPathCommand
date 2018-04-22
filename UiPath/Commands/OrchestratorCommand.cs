﻿using System;
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
            //TODO 各項目のチェック処理があれば追加で実装する（デフォルト値の設定処理も含めて）
            model.HostName = OrchestratorConfig.HostName;
            model.Password = OrchestratorConfig.Password;
            model.TenantName = OrchestratorConfig.TenantName;
            model.UserId = OrchestratorConfig.UserId;
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
            this.ExecuteAuthenticate(model);

            foreach (var command in model.Commands)
            {
                switch (command)
                {
                    case "Release":
                        this.ExecuteGetReleaseDto(model);
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

        private void ExecuteAuthenticate(OrchestartorModel model)
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
        private void ExecuteGetSettingsDto(OrchestartorModel model)
        {
            string url = $"https://{model.HostName}/odata/Settings";
            var task = HttpClientManager.ExecuteGetAsync<OrcSettingsDto>(url);
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

        #region ExecuteGetRobotsDto

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

        #endregion

        #endregion
    }
}