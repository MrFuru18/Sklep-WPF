using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_WPF.Navigation;
using System.Windows.Input;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
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

        private ICommand _login;
        public ICommand Login
        {
            get
            {
                return _login ?? (_login= new RelayCommand((p) =>
                {
                    _navigate.CurrentPage = new UserViewModel();
                   
                }, p => true));
            }
        }

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
