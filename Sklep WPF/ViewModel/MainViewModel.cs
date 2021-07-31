using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Sklep_WPF.Navigation;
using Sklep_WPF.CurrentSession;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;

    class MainViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        private readonly ProductStore _productStore;
        private readonly Navigate _navigate;

        public ViewModelBase CurrentPage => _navigate.CurrentPage;
        public bool LoggedIn => _accountStore.IsLoggedIn;
        public bool LoggedOut => !_accountStore.IsLoggedIn;

        public ICommand LogoutCommand { get; }

        public MainViewModel(AccountStore accountStore, ProductStore productStore, Navigate navigate)
        {
            _accountStore = accountStore;
            _productStore = productStore;
            _navigate = navigate;
            _navigate.CurrentPageChanged += OnCurrentPageChanged;
            LogoutCommand = new LogoutCommand(accountStore, navigate);
        }

        private void OnCurrentPageChanged()
        {
            onPropertyChanged(nameof(CurrentPage));
            onPropertyChanged(nameof(LoggedIn));
            onPropertyChanged(nameof(LoggedOut));
        }

        private ICommand _uptadeViewCommand;
        public ICommand UptadeViewCommand
        {
            get
            {
                return _uptadeViewCommand ?? (_uptadeViewCommand = new RelayCommand((p) =>
                {
                    if (p.ToString() == "User")
                    {
                        _navigate.CurrentPage = new UserViewModel(_accountStore);
                    }
                    else if (p.ToString() == "Shop")
                    {
                        _navigate.CurrentPage = new ShopViewModel(_productStore);
                    }
                    else if (p.ToString() == "Cart")
                    {
                        _navigate.CurrentPage = new CartViewModel(_productStore);
                    }
                    else if (p.ToString() == "Order History")
                    {
                        _navigate.CurrentPage = new OrderHistoryViewModel();
                    }
                    else if (p.ToString() == "Settings")
                    {
                        _navigate.CurrentPage = new SettingsViewModel();
                    }
                    else if (p.ToString() == "Login")
                    {
                        _navigate.CurrentPage = new LoginViewModel(_accountStore, _navigate);
                    }
                    else if(p.ToString() == "Logout")
                    {
                        _navigate.CurrentPage = new LoginViewModel(_accountStore, _navigate);
                    }


                }, p => true));
            }
        }
    }
}
