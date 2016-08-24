using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginComponent
{
    public interface ILoginDataMapper
    {
        void Create(User u);
        void Delete(User u);
        void Login(User u);
    }
}
