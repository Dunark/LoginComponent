using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoginModule_Test
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            LoginComponent.ILoginDataMapper fdm = new LoginComponent.MsqlLoginDataMapper("Connection string");
            LoginComponent.Login l = new LoginComponent.Login(fdm);
            l.CreateUser("bejo@eal.dk", "123", "123");
        }
    }
}
