using Sklep_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.CurrentSession
{
    using Model;
    class AccountStore
    {
        private User _currentAccount;
        public User CurrentAccount
        {
            get => _currentAccount;
            set
            {
                _currentAccount = value;
            }
        }

        public bool IsLoggedIn => _currentAccount != null;
    }
}
