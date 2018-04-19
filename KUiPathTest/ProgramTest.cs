using KUiPath;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KUiPath.Manager;
using KUiPath.Commands;
using System.Reflection;

namespace KUiPath.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        #region Error_Test

        [TestMethod()]
        public void MainTest_NoArgs_errorLevel()
        {
            Program.Main(new string[] { });
            var actual = CommandManager.ResultList[(nameof(InformationCommand))];
            Assert.IsTrue(actual.Contains("usage: KUiPath"));
        }

        [TestMethod()]
        public void MainTest_NoArgs_message()
        {
            Program.Main(new string[] { });
            var actual = CommandManager.ResultList[(nameof(InformationCommand))];
            Assert.IsTrue(actual.Contains("usage: KUiPath"));

        }

        [TestMethod()]
        public void MainTest_SameOption()
        {
            Program.Main(new string[] { "-v", "-v"  });
            var actual = CommandManager.ResultList[(nameof(InformationCommand))];
            Assert.IsTrue(actual.Contains("usage: KUiPath"));
        }

        #endregion

        #region Normal_Test

        #region version_Option

        [TestMethod()]
        public void MainTest_v()
        {
            Program.Main(new string[] { "-v" });
            var actual = CommandManager.ResultList[(nameof(VersionCommand))];

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            var expected = $"KUiPath command {version}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MainTest_version()
        {
            Program.Main(new string[] { "--version" });
            var actual = CommandManager.ResultList[(nameof(VersionCommand))];

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            var expected = $"KUiPath command {version}";

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region information_Option

        [TestMethod()]
        public void MainTest_i()
        {
            Program.Main(new string[] { "-i" });
            var actual = CommandManager.ResultList[(nameof(InformationCommand))];
            Assert.IsTrue(actual.Contains("usage: KUiPath"));
        }

        [TestMethod()]
        public void MainTest_info()
        {
            Program.Main(new string[] { "--info" });
            var actual = CommandManager.ResultList[(nameof(InformationCommand))];
            Assert.IsTrue(actual.Contains("usage: KUiPath"));
        }
        [TestMethod()]
        public void MainTest_question()
        {
            Program.Main(new string[] { "-?" });
            var actual = CommandManager.ResultList[(nameof(InformationCommand))];
            Assert.IsTrue(actual.Contains("usage: KUiPath"));
        }

        [TestMethod()]
        public void MainTest_help()
        {
            Program.Main(new string[] { "--help" });
            var actual = CommandManager.ResultList[(nameof(InformationCommand))];
            Assert.IsTrue(actual.Contains("usage: KUiPath"));
        }
        #endregion

        #endregion
    }
}