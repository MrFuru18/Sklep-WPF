using Sklep_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sklep_WPF.Navigation
{
    class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly Navigate _navigate;

        public LoginCommand(LoginViewModel viewModel, Navigate navigate)
        {
            _viewModel = viewModel;
            _navigate = navigate;
        }
        public override void Execute(object p)
        {
            MessageBox.Show("Email: " + _viewModel.Email);

            _navigate.CurrentPage = new UserViewModel();
        }
    }
}
