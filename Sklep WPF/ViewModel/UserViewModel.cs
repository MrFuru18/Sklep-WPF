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

            addresses = new BindingList<Address>();
            Address address1 = new Address()
            {
                ulica = "ulica1",
                nr = 111,
                nr_mieszkania = 222,
                kod_pocztowy = "40-100",
                miejscowosc = "miejscowosc1"
            };
            Address address2 = new Address()
            {
                ulica = "ulica2",
                nr = 222,
                nr_mieszkania = 333,
                kod_pocztowy = "40-150",
                miejscowosc = "miejscowosc2"
            };
            Address address3 = new Address()
            {
                ulica = "ulica3",
                nr = 444,
                nr_mieszkania = 555,
                kod_pocztowy = "40-160",
                miejscowosc = "miejscowosc3"
            };
            Address address4 = new Address()
            {
                ulica = "ulica4",
                nr = 666,
                nr_mieszkania = 666,
                kod_pocztowy = "40-170",
                miejscowosc = "miejscowosc4"
            };
            addresses.Add(address1);
            addresses.Add(address2);
            addresses.Add(address3);
            addresses.Add(address4);
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
                    addresses.Remove(selectedAddress);
                    MessageBox.Show("Adres usunięty");

                }, p => true));
            }
        }
    }
}
