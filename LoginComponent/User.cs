using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginComponent
{
    public class User
    {
        public static User LoggedInUser { get; set; }
        public string _email { get; set; }
        public string _hashedPassword { get; set; }

        public User(string email, string hashedPassword)
        {
            _email = email;
            _hashedPassword = hashedPassword;
        }

    }
}
