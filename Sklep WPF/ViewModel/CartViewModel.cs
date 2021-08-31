using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Sklep_WPF.Navigation;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    using Sklep_WPF.Model;
    using Sklep_WPF.CurrentSession;

    class CartViewModel : ViewModelBase
    {
        private readonly ProductStore _productStore;
        private readonly Navigate _navigate;

        public List<Product> products { get; set; }

        public CartViewModel(ProductStore productStore, Navigate navigate)
        {
            _productStore = productStore;
            _navigate = navigate;

            products = _productStore.products;
        }

        private ICommand _prodceedToCheckout;
        public ICommand ProceedToCheckout
        {
            get
            {
                return _prodceedToCheckout ?? (_prodceedToCheckout = new RelayCommand((p) =>
                {
                    _navigate.CurrentPage = new CheckoutViewModel();

                }, p => true));
            }
        }
    }
}
