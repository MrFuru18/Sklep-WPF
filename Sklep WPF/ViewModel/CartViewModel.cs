using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Sklep_WPF.Model;
using Sklep_WPF.Navigation;
using Sklep_WPF.CurrentSession;
using Sklep_WPF.Navigation.PopupService;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    class CartViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        private readonly CartProductStore _productStore;
        private readonly Navigate _navigate;
        private readonly IDialogService _dialogService;

        public BindingList<ProductCart> cartProducts => _productStore?.cartProducts; //{ get; set; }

        public CartViewModel(AccountStore accountStore, CartProductStore productStore, Navigate navigate, IDialogService dialogService)
        {
            _accountStore = accountStore;
            _productStore = productStore;
            _navigate = navigate;
            _dialogService = dialogService;

            //cartProducts = _productStore.cartProducts;
        }

        private ICommand _deleteFromCart;
        public ICommand DeleteFromCart
        {
            get
            {
                return _deleteFromCart ?? (_deleteFromCart = new RelayCommand((p) =>
                {
                    ProductCart selectedProduct = new ProductCart();
                    selectedProduct = (ProductCart)p;
                    _productStore.RemoveProduct(selectedProduct);

                }, p => true));
            }
        }

        private ICommand _prodceedToCheckout;
        public ICommand ProceedToCheckout
        {
            get
            {
                return _prodceedToCheckout ?? (_prodceedToCheckout = new RelayCommand((p) =>
                {
                    if (_accountStore.IsLoggedIn)
                    {
                        if (_productStore.IsEmpty == true)
                            _navigate.CurrentPage = new CheckoutViewModel(_accountStore, _productStore, _navigate, _dialogService);
                        else
                            MessageBox.Show("Koszyk jest pusty");
                    }
                    else
                        MessageBox.Show("Musisz być zalogowany");
                    

                }, p => true));
            }
        }
    }
}
