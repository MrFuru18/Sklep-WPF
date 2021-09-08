using Sklep_WPF.CurrentSession;
using Sklep_WPF.Model;
using Sklep_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Sklep_WPF.DAL.Repozytoria;
using Sklep_WPF.Navigation.PopupService;
using Sklep_WPF.ViewModel.PopupVM;

namespace Sklep_WPF.Navigation
{
    class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly Navigate _navigate;
        private readonly IDialogService _dialogService;

        public LoginCommand(LoginViewModel viewModel, AccountStore accountStore ,Navigate navigate,IDialogService dialogService)
        {
            _viewModel = viewModel;
            _accountStore = accountStore;
            _navigate = navigate;
            _dialogService = dialogService;
        }
        public override void Execute(object p)
        {
            LoginModel account = new LoginModel()
            {
                email = _viewModel.Email,
                password = _viewModel.Password
            };

            if (string.IsNullOrWhiteSpace(account.email) || string.IsNullOrWhiteSpace(account.password))
            {
                var result = _dialogService.OpenDialog(new AlertDialogViewModel("Pola nie mogą być puste"));
            }
            else
            {
                _accountStore.CurrentAccount = UserRepo.Login(account).Result;
                if (_accountStore.IsLoggedIn)
                    _navigate.CurrentPage = new UserViewModel(_accountStore, _dialogService);
                else
                {
                    var result = _dialogService.OpenDialog(new AlertDialogViewModel("Dane logowania nieprawidłowe"));
                }
            }
        }
    }
}
