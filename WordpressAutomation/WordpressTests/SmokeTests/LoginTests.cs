using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class LoginTests : BaseTest
    {
        [TestMethod]
        public void AdminUserCanLogin()
        {
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login.");
        }
    }
}