using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.CurrentSession
{
    using Model;
    using System.ComponentModel;
    using ViewModel;
    class ProductStore
    {
        //public List<Product> products { get; set; }
        public BindingList<ProductCart> cartProducts { get; set; }
        bool counted;

        public ProductStore()
        {
            //products = new List<Product>();
            cartProducts = new BindingList<ProductCart>();
        }

        public void AddProduct(Product product)
        {
            counted = false;
            //products.Add(product);

            ProductCart _product = new ProductCart()
            {
                id = product.id,
                name = product.nazwa,
                price = product.cena,
                description = product.opis,
                quantity = 1
            };
            for (var i = 0; i < cartProducts.Count; i++)
            {
                if (_product.name == cartProducts[i].name) //       !!! zmienić na id po podłączeniu do bazy !!!
                {
                    cartProducts[i].quantity++;
                    counted = true;
                }
            }

            if (counted == false)
                cartProducts.Add(_product);
        }

        public void RemoveProduct(ProductCart product)
        {
            for (var i = 0; i < cartProducts.Count; i++)
            {
                if (product.name == cartProducts[i].name) //       !!! zmienić na id po podłączeniu do bazy !!!
                {
                    cartProducts[i].quantity--;
                    cartProducts.ResetItem(i);
                    if (cartProducts[i].quantity == 0)
                        cartProducts.RemoveAt(i);
                }
            }
        }
        
    }
}
