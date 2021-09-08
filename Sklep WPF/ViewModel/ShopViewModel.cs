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
using Sklep_WPF.CurrentSession;
using System.ComponentModel;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    

    class ShopViewModel : ViewModelBase
    {
        private readonly CartProductStore _productStore;
        public BindingList<Product> products { get; set; }
        public List<string> sort { get; set; }


        public ShopViewModel(CartProductStore productStore)
        {
            _productStore = productStore;

            sort = new List<string>();
            sort.Add("Cena rosnąco");
            sort.Add("Cena malejąco");

            products = new BindingList<Product>(ProductRepo.getAllProtucts().Result);
        }

        private string _sortBy;
        public string SortBy
        {
            get { return _sortBy; }
            set
            {
                _sortBy = value;
                if (_sortBy=="Cena malejąco")
                {
                    List<Product> SortedProducts = products.OrderByDescending(o => o.cena).ToList();
                    products.Clear();
                    foreach (var product in SortedProducts)
                        products.Add(product);
                }
                if (_sortBy == "Cena rosnąco")
                {
                    List<Product> SortedProducts = products.OrderBy(o => o.cena).ToList();
                    products.Clear();
                    foreach (var product in SortedProducts)
                        products.Add(product);
                }
            }
        }

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

                }, p => true));
            }
        }


    }
}
