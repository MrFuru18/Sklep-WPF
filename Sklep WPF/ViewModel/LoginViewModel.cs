using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Security;
using System.Windows;
using Sklep_WPF.Navigation;
using Sklep_WPF.Model;
using Sklep_WPF.CurrentSession;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    using Sklep_WPF.CurrentSession;
    using System.Security;

    class LoginViewModel : ViewModelBase
    {
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

        public string Password { get; set; }

        public ICommand Login { get; }
        public ICommand Signup { get; }

        public LoginViewModel(AccountStore accountStore, Navigate navigate)
        {
            Login = new LoginCommand(this, accountStore, navigate);
            Signup = new NavigateCommand<SignupViewModel>(navigate, () => new SignupViewModel());
        }


    }
}
