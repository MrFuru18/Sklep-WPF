using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.CurrentSession
{
    using Model;
    using ViewModel;
    class ProductStore
    { 
        public List<Product> products { get; set; }

        public ProductStore()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        
    }
}
