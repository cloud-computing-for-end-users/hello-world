using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.Fail("I made this to demon strate a test fail");
        }


        [TestMethod]
        public void TestMethod2()
        {
            //made this to show a test sucess
        }
    }
}
