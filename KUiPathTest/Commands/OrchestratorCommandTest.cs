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
        public void TestMethod2()
        {
            OrchestratorConfig.Commands.Add("Release");
            OrchestratorCommand comand = new OrchestratorCommand();
            var model = comand.CreateCommandModel();
            comand.ExecuteCommand(model);
        }

        [TestMethod]
        public void TestMethod3()
        {
            OrchestratorConfig.Commands.Add("Robots");
            OrchestratorCommand comand = new OrchestratorCommand();
            var model = comand.CreateCommandModel();
            comand.ExecuteCommand(model);
        }

        [TestMethod]
        public void TestMethod4()
        {
            OrchestratorConfig.Commands.Add("Settings");
            OrchestratorCommand comand = new OrchestratorCommand();
            var model = comand.CreateCommandModel();
            comand.ExecuteCommand(model);
        }
    }
}
