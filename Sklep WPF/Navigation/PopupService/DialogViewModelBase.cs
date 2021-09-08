using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Navigation.PopupService
{
    public abstract class DialogViewModelBase<T>
    {
        public string Message { get; set; }
        public T DialogResult { get; set; }

        public DialogViewModelBase(string message)
        {
            Message = message;
        }

        public void CloseDialogWithResult(IDialogWindow dialog, T result)
        {
            DialogResult = result;

            if (dialog != null)
                dialog.DialogResult = true;
        }
    }
}
