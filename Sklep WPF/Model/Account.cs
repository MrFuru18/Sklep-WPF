using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace Sklep_WPF.Model
{
    class Account
    {
        public string Email { get; set; }
        public SecureString Password { get; set; }

    }
}
