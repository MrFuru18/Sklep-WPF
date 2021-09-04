using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_WPF.Model;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using Sklep_WPF.DAL.Repozytoria;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    using Sklep_WPF.CurrentSession;

    class ShopViewModel : ViewModelBase
    {
        private readonly CartProductStore _productStore;
        public List<Product> products { get; set; }


        public ShopViewModel(CartProductStore productStore)
        {
            _productStore = productStore;

            products = ProductRepo.getAllProtucts().Result;
        }


        //public string Quantity { get; set; }


        private ICommand _addToCart;
        public ICommand AddToCart
        {
            get
            {
                return _addToCart ?? (_addToCart = new RelayCommand((p) =>
                {
                    Product selectedProduct = new Product();
                    selectedProduct = (Product)p;
                    _productStore.AddProduct(selectedProduct);
                    //MessageBox.Show("Clicked on " + selectedProduct.nazwa/* + "\nQuantity: " + Quantity*/);
                    //Quantity = null;

                }, p => true));
            }
        }


    }
}
