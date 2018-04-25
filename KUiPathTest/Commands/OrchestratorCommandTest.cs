using System;
using KUiPath.Commands;
using KUiPath.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KUiPathTest.Commands
{
    [TestClass]
    public class OrchestratorCommandTest
    {
        [TestInitialize]
        public void InitProcess()
        {
            OrchestratorConfig.HostName = "academy2016.uipath.com";
            OrchestratorConfig.TenantName = "";
            OrchestratorConfig.UserId = "";
            OrchestratorConfig.Password = "";
        }

        [TestMethod]
        public void TestMethod_Release()
        {
            OrchestratorConfig.Commands.Add("Release");
            OrchestratorCommand comand = new OrchestratorCommand();
            var model = comand.CreateCommandModel();
            comand.ExecuteCommand(model);
        }

        [TestMethod]
        public void TestMethod_Robots()
        {
            OrchestratorConfig.Commands.Add("Robots");
            OrchestratorCommand comand = new OrchestratorCommand();
            var model = comand.CreateCommandModel();
            comand.ExecuteCommand(model);
        }

        [TestMethod]
        public void TestMethod_Settings()
        {
            OrchestratorConfig.Commands.Add("Settings");
            OrchestratorCommand comand = new OrchestratorCommand();
            var model = comand.CreateCommandModel();
            comand.ExecuteCommand(model);
        }
    }
}
