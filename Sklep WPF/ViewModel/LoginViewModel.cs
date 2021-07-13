using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_WPF.Navigation;
using System.Windows.Input;
using System.Windows;
using Sklep_WPF.Model;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
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

        public SecureString SecurePassword { private get; set; }

        public ICommand Login { get; }
        public ICommand Signup { get; }

        public LoginViewModel(Navigate navigate)
        {
            Login = new LoginCommand(this, navigate);
            Signup = new NavigateCommand<SignupViewModel>(navigate, () => new SignupViewModel());
        }


    }
}
