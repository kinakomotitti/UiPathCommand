using KUiPath;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KUiPath.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void MainTest()
        {
            var actual = Program.Main(new string[] { "-v" });
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}