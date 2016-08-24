using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginComponent
{
    class CreateUserCommand : ICommand
    {
        private string _email;
        private string _password;
        private string _confirmPassword;
        private ILoginDataMapper _dm;

        public CreateUserCommand(string email, string password, string confirmPassword, ILoginDataMapper dm)
        {
            _email = email;
            _password = password;
            _confirmPassword = confirmPassword;
            _dm = dm;
        }
        public void Execute()
        {
            Helper.chkEmail(_email);
            Helper.chkPassword(_password);
            Helper.chkPassword(_confirmPassword);
            if (!_password.Equals(_confirmPassword))
                throw new Exception("Not same password");
            User u = new User(_email, Helper.HashPassword(_password));
            _dm.Create(u);
        }
    }
}
