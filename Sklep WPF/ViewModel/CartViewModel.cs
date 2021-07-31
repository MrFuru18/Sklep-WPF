using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    using Sklep_WPF.Model;
    using Sklep_WPF.CurrentSession;

    class CartViewModel : ViewModelBase
    {
        private readonly ProductStore _productStore;
        public List<Product> products { get; set; }

        public CartViewModel(ProductStore productStore)
        {
            _productStore = productStore;

            products = _productStore.products;
        }

    }
}
