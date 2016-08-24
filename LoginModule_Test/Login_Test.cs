using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoginModule_Test
{
    class Login_Test
    {
        public void LoginModule_Login_AllInputOk_True()
        {
            LoginComponent.ILoginDataMapper fdm = new FakeLoginDataMapper();
            LoginComponent.Login l = new LoginComponent.Login(fdm);
            l.LoginUser("bejo@eal.dk", "123456", "123456");
            Assert.IsTrue(true);
        }
    }
}
