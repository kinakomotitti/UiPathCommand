using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUiPath.Config;
using KUiPath.Manager;
using KUiPath.Models;

namespace KUiPath.Commands
{
    class OrchestratorCommand : ICommand
    {
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


        public FlagManager.ProcessStatus ExecuteCommand(ICommandModel model)
        {
            return this.ExecuteCommandAsync(model as OrchestartorModel).Result;
        }

        private async Task<FlagManager.ProcessStatus> ExecuteCommandAsync(OrchestartorModel model)
        {
            await this.ExecuteAuthenticate(model);
            foreach (var command in model.Commands)
            {

                if (model.Commands.Contains("Release")) await this.ExecuteGetReleaseDto(model);

            }

            return FlagManager.ProcessStatus.Success;
        }

        #region Authenticate

        private async Task ExecuteAuthenticate(OrchestartorModel model)
        {
            var contents = new OrcAuthenticationModel()
            {
                password = model.Password,
                tenancyName = model.TenantName,
                usernameOrEmailAddress = model.UserId
            };
            string url = $"https://{model.HostName}/api/account/authenticate";
            var responce = await HttpClientManager.ExecutePostAsync<OrcAuthenticationModel>(url, contents);
            HttpClientManager.BearerValue = responce.result;
        }

        #endregion

        #region ReleaseDto

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private async Task ExecuteGetReleaseDto(OrchestartorModel model)
        {
            string url = $"https://{model.HostName}/odata/Releases";
            var result = await HttpClientManager.ExecuteGetAsync<OrcReleaseDtoModel>(url);
            foreach (var item in result.value)
            {
                CommandManager.ResultList.Add(DateTime.Now.ToString("mmddss.ffff").ToString(), $"{item.Name},{item.Key},{item.ProcessVersion}");
            }
        }

        #endregion
    }
}
