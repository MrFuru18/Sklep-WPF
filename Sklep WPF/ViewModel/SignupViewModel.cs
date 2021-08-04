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
    class SignupViewModel : ViewModelBase
    {
        #region properties
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

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                onPropertyChanged(nameof(Name));
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                onPropertyChanged(nameof(Surname));
            }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                onPropertyChanged(nameof(Number));
            }
        }
        #endregion

        public ICommand Signup { get; }

        public SignupViewModel(AccountStore accountStore, Navigate navigate)
        {
            Signup = new RegisterCommand(this, accountStore, navigate);
        }

    }
}
