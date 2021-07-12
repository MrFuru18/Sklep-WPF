using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_WPF.Navigation;
using System.Windows.Input;
using System.Windows;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    using System.Security;

    class LoginViewModel : ViewModelBase
    {
        private readonly Navigate _navigate;

        public ViewModelBase CurrentPage => _navigate.CurrentPage;

        public LoginViewModel(Navigate navigate)
        {
            _navigate = navigate;
            _navigate.CurrentPageChanged += OnCurrentPageChanged;
        }

        private void OnCurrentPageChanged()
        {
            onPropertyChanged(nameof(CurrentPage));
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                onPropertyChanged(nameof(Email));
            }
        }

        public SecureString SecurePassword { private get; set; }


        //                                                                                  Login Button
        private ICommand _login;
        public ICommand Login
        {
            get
            {
                return _login ?? (_login= new RelayCommand((p) =>
                {

                    if (Email != null && Email != "" && SecurePassword != null)
                    {
                        /*
                        //weryfikacja danych logowania
                        if ()
                        {
                            _navigate.CurrentPage = new UserViewModel();
                        }
                        */

                        MessageBox.Show("Email: " + Email + "\nPassword: " + SecurePassword);
                        _navigate.CurrentPage = new UserViewModel();
                    }
                    else 
                    {
                        MessageBox.Show("Pola nie mogą być puste");
                    }
                   
                }, p => true));
            }
        }

        //                                                                                  Signup Button
        private ICommand _signup;
        public ICommand Signup
        {
            get
            {
                return _signup ?? (_signup = new RelayCommand((p) =>
                {
                    _navigate.CurrentPage = new SignupViewModel();

                }, p => true));
            }
        }


        /*
        public ICommand Login { get; }

        public LoginViewModel(Navigate navigate)
        {
            Login = new NavigateCommand<UserViewModel>(navigate, () => new UserViewModel()) ;
        }
        */
    }
}
