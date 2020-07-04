using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework1
{
    [TestClass]
    class NamespaceSetup
    {
        [AssemblyInitialize]
        public static void ExecuteForAutomationFramework1Namespace(TestContext testContext)
        {
            Reporter.StartReporter();
        }
    }
}
