using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_WPF.Navigation;
using System.Windows.Input;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    class InfoViewModel : ViewModelBase
    {
       
        private ICommand _github;
        public ICommand Github
        {
            get
            {
                return _github?? (_github = new RelayCommand((p) =>
                {
                    System.Diagnostics.Process.Start("https://github.com/MrFuru18/Sklep-WPF");

                }, p => true));
            }
        }
    }
}
