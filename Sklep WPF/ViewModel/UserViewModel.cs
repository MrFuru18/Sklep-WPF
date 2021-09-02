using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_WPF.Model;
using Sklep_WPF.CurrentSession;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;

    class UserViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;


        public string Email => _accountStore.CurrentAccount?.email;
        public string Name => _accountStore.CurrentAccount?.imie;
        public string Surname => _accountStore.CurrentAccount?.nazwisko;
        public string PhoneNumber => _accountStore.CurrentAccount?.nr_tel;
        public string Address;
        public UserViewModel(AccountStore accountStore)
        {
            _accountStore = accountStore;
        }
    }
}
