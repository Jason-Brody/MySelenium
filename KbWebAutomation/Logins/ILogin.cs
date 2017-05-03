using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KbWebAutomation.Logins {
    public interface ILogin {
        void Login(string userName, string password);
    }
}
