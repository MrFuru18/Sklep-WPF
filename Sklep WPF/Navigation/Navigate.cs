using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_WPF.ViewModel.BaseClass;

namespace Sklep_WPF.Navigation
{
    class Navigate
    {
        public event Action CurrentPageChanged;

        private ViewModelBase _currentPage;
        public ViewModelBase CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage?.Dispose();
                _currentPage = value;
                OnCurrentPageChanged();
            }
        }
        private void OnCurrentPageChanged()
        {
            CurrentPageChanged?.Invoke();
        }
    }
}
