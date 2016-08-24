using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoginModule_Test
{
    [TestClass]
    public class CreateAndDeleteUser_Test
    {
        [TestMethod]
        public void LoginModule_CreateUser_AllInputOk_Void()
        {
            LoginComponent.ILoginDataMapper fdm = new FakeLoginDataMapper();
            LoginComponent.Login l = new LoginComponent.Login(fdm);
            l.CreateUser("bejo@eal.dk", "123456", "123456");
            l.DeleteUser("bejo@eal.dk", "123456", "123456");
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoginModule_CreateUser_ShortPassword_Exception()
        {
            bool failed = false;
            try
            {
                LoginComponent.ILoginDataMapper fdm = new FakeLoginDataMapper();
                LoginComponent.Login l = new LoginComponent.Login(fdm);
                l.CreateUser("bejo@eal.dk", "123", "123");
                l.DeleteUser("bejo@eal.dk", "123", "123");
            }
            catch (Exception)
            {
                failed = true;
            }
            Assert.IsTrue(failed);
        }
    }
}
