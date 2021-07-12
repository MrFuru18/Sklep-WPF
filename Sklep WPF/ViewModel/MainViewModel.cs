﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Sklep_WPF.Navigation;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    class MainViewModel : ViewModelBase
    {
        private readonly Navigate _navigate;

        public ViewModelBase CurrentPage => _navigate.CurrentPage;

        public MainViewModel(Navigate navigate)
        {
            _navigate = navigate;
            _navigate.CurrentPageChanged += OnCurrentPageChanged;
        }

        private void OnCurrentPageChanged()
        {
            onPropertyChanged(nameof(CurrentPage));
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
                        _navigate.CurrentPage = new UserViewModel();
                    }
                    else if (p.ToString() == "Shop")
                    {
                        _navigate.CurrentPage = new ShopViewModel();
                    }
                    else if (p.ToString() == "Cart")
                    {
                        _navigate.CurrentPage = new CartViewModel();
                    }
                    else if (p.ToString() == "Order History")
                    {
                        _navigate.CurrentPage = new OrderHistoryViewModel();
                    }
                    else if (p.ToString() == "Settings")
                    {
                        _navigate.CurrentPage = new SettingsViewModel();
                    }
                    else if(p.ToString() == "Logout")
                    {
                        _navigate.CurrentPage = new LoginViewModel(_navigate);
                    }


                }, p => true));
            }
        }
    }
}
