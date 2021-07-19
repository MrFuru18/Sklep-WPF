using Sklep_WPF.CurrentSession;
using Sklep_WPF.Model;
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
        private readonly AccountStore _accountStore;
        private readonly Navigate _navigate;

        public LogoutCommand(AccountStore accountStore, Navigate navigate)
        {
            _accountStore = accountStore;
            _navigate = navigate;
        }
        public override void Execute(object p)
        {
            _accountStore.CurrentAccount = null;
            _navigate.CurrentPage = new LoginViewModel(_accountStore, _navigate);
        }
    }
}
