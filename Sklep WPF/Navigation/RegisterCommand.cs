using Sklep_WPF.CurrentSession;
using Sklep_WPF.DAL.Repozytoria;
using Sklep_WPF.Model;
using Sklep_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Navigation
{
    class RegisterCommand : CommandBase
    {
        private readonly SignupViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly Navigate _navigate;

        public RegisterCommand(SignupViewModel viewModel, AccountStore accountStore, Navigate navigate)
        {
            _viewModel = viewModel;
            _accountStore = accountStore;
            _navigate = navigate;
        }
        public override void Execute(object p)
        {
            RegisterModel account = new RegisterModel()
            {
                email = _viewModel.Email,
                password = _viewModel.Password,
                firstName = _viewModel.Name,
                lastName = _viewModel.Surname,
                phoneNumber = _viewModel.Number
            };
            _accountStore.CurrentAccount = UserRepo.Register(account).Result;
            _navigate.CurrentPage = new UserViewModel(_accountStore);
        }

    }
}
