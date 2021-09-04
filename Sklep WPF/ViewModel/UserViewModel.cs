using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_WPF.Model;
using Sklep_WPF.CurrentSession;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using Sklep_WPF.DAL.Repozytoria;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;

    class UserViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        public BindingList<Address> addresses { get; set; }

        public string Email => _accountStore.CurrentAccount?.email;
        public string Name => _accountStore.CurrentAccount?.imie;
        public string Surname => _accountStore.CurrentAccount?.nazwisko;
        public string PhoneNumber => _accountStore.CurrentAccount?.nr_tel;

        public UserViewModel(AccountStore accountStore)
        {
            _accountStore = accountStore;

            addresses = new BindingList<Address>(AddressRepo.getAllAddresses().Result);
        }

        private ICommand _removeAddress;
        public ICommand RemoveAddress
        {
            get
            {
                return _removeAddress ?? (_removeAddress = new RelayCommand((p) =>
                {
                    Address selectedAddress = new Address();
                    selectedAddress = (Address)p;
                    //addresses.Remove(selectedAddress);
                    //MessageBox.Show("Adres usunięty");

                }, p => true));
            }
        }
    }
}
