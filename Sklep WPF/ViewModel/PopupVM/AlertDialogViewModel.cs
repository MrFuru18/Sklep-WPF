using Sklep_WPF.Navigation.PopupService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sklep_WPF.ViewModel.PopupVM
{
    public class AlertDialogViewModel : DialogViewModelBase<DialogResult>
    {
       public ICommand OKCommand { get; private set; }

        public AlertDialogViewModel(string message):base(message)
        {
            OKCommand = new RelayCommand<IDialogWindow>(OK);
        }

        private void OK(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResult.Undefined);
        }
    }
}
