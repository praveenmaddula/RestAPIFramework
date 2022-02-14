using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedAPITests
{
    [TestClass]
    public class TestBase
    {
        //Setup and logging can be done in this class 
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestCaseInit()
        {
            //Test Initialisation code will go here
            Log("START TEST >> " + TestContext.TestName + " @ " + DateTime.Now.ToLocalTime().ToString());
        }

        public virtual void Log(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);
            TestContext.WriteLine(message);
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            //Test cleanup code will go here
        }

    }
    
}
