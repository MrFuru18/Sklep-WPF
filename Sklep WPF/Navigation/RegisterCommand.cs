using Sklep_WPF.CurrentSession;
using Sklep_WPF.DAL.Repozytoria;
using Sklep_WPF.Model;
using Sklep_WPF.Navigation.PopupService;
using Sklep_WPF.ViewModel;
using Sklep_WPF.ViewModel.PopupVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sklep_WPF.Navigation
{
    class RegisterCommand : CommandBase
    {
        private readonly SignupViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly Navigate _navigate;
        private readonly IDialogService _dialogService;

        public RegisterCommand(SignupViewModel viewModel, AccountStore accountStore, Navigate navigate, IDialogService dialogService)
        {
            _viewModel = viewModel;
            _accountStore = accountStore;
            _navigate = navigate;
            _dialogService = dialogService;
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

            if (string.IsNullOrWhiteSpace(account.email) || string.IsNullOrWhiteSpace(account.password) || string.IsNullOrWhiteSpace(account.firstName) || string.IsNullOrWhiteSpace(account.lastName) || string.IsNullOrWhiteSpace(account.phoneNumber))
            {
                _dialogService.OpenDialog(new AlertDialogViewModel("Pola nie mogą być puste"));
            }
            else if (!IsValidEmail(account.email))
            {
                _dialogService.OpenDialog(new AlertDialogViewModel("Adres email nieprawidłowy"));
            }
            else if (account.password.Length < 8)
            {
                _dialogService.OpenDialog(new AlertDialogViewModel("Hasło musi mieć przynajmniej 8 znaków"));
            }
            else if (!long.TryParse(account.phoneNumber, out long value) || !long.TryParse(account.phoneNumber, out value))
            {
                _dialogService.OpenDialog(new AlertDialogViewModel("Numer telefonu nieprawidłowy"));
            }
            else
            {
                RegisterResult res = UserRepo.Register(account).Result;
                if(res!=null)
                {
                    if(res.succeeded)
                    {
                        _dialogService.OpenDialog(new AlertDialogViewModel("Konto zostało założone"));
                        _navigate.CurrentPage = new LoginViewModel(_accountStore, _navigate, _dialogService);
                    }
                    else
                    {
                        _dialogService.OpenDialog(new AlertDialogViewModel($"{res.errors[0].description}"));
                    }
                }
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
