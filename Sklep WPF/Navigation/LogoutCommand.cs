using Sklep_WPF.CurrentSession;
using Sklep_WPF.DAL.Repozytoria;
using Sklep_WPF.Model;
using Sklep_WPF.Navigation.PopupService;
using Sklep_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Navigation
{
    class LogoutCommand : CommandBase
    {
        private readonly IDialogService _dialogService;
        private readonly AccountStore _accountStore;
        private readonly Navigate _navigate;

        public LogoutCommand(AccountStore accountStore, Navigate navigate, IDialogService dialogService)
        {
            _accountStore = accountStore;
            _navigate = navigate;
            _dialogService = dialogService;
        }
        public override void Execute(object p)
        {
            _accountStore.CurrentAccount = null;
            UserRepo.Logout();
            _navigate.CurrentPage = new LoginViewModel(_accountStore, _navigate, _dialogService);
        }
    }
}
