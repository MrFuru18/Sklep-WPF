using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_WPF.ViewModel;
using Sklep_WPF.ViewModel.BaseClass;

namespace Sklep_WPF.Navigation
{
    class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private readonly Navigate _navigate;
        private readonly Func<TViewModel> _createViewModel;

        public NavigateCommand(Navigate navigate, Func<TViewModel> createViewModel)
        {
            _navigate = navigate;
            _createViewModel = createViewModel;
        }

        public override void Execute(object p)
        {
            _navigate.CurrentPage = _createViewModel();
        }
    }
}
