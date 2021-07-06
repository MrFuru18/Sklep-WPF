﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase _selectedPage = new LoginViewModel();
        public ViewModelBase SelectedPage
        {
            get { return _selectedPage; }
            set 
            { 
                _selectedPage = value;
                onPropertyChanged(nameof(SelectedPage));
            }
        }

        private ICommand _uptadeViewCommand;
        public ICommand UptadeViewCommand
        {
            get
            {
                return _uptadeViewCommand ?? (_uptadeViewCommand = new RelayCommand((p) =>
                {
                    if (p.ToString() == "Settings")
                    {
                        SelectedPage = new SettingsViewModel();
                    }
                    else if(p.ToString() == "Login")
                    {
                        SelectedPage = new LoginViewModel();
                    }


                }, p => true));
            }
        }
    }
}
