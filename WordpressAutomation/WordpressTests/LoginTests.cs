using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class LoginTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void AdminUserCanLogin()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("admin")
                .WithPassword("Niko8603")
                .Login();

            Assert.IsTrue(DashboardPage.IsAt, "Failed to login.");
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Instance.Close();
        }
    }
}