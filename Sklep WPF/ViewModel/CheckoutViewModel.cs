using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    using Sklep_WPF.CurrentSession;
    using Sklep_WPF.Model;
    using Sklep_WPF.Navigation;
    using System.Windows;

    class CheckoutViewModel : ViewModelBase
    {
        private readonly ProductStore _productStore;
        private readonly Navigate _navigate;

        public CheckoutViewModel(ProductStore productStore, Navigate navigate)
        {
            _productStore = productStore;
            _navigate = navigate;

            Price = _productStore.ShowPrice();
        }

        public string Price { get; set; }

        private ICommand _placeOrder;
        public ICommand PlaceOrder
        {
            get
            {
                return _placeOrder ?? (_placeOrder = new RelayCommand((p) =>
                {
                    _productStore.ClearCart();
                    _navigate.CurrentPage = new CartViewModel(_productStore, _navigate);
                    MessageBox.Show("Zamówienie złożono pomyślnie");

                }, p => true));
            }
        }
    }
}
