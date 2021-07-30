using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_WPF.Model;
using System.Windows.Input;
using System.Windows;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;

    class ShopViewModel : ViewModelBase
    {
        public List<Product> products { get; set; }
        public ShopViewModel()
        {
            products = new List<Product>();
            Product product1 = new Product();
            product1.nazwa = "produkt1";
            product1.cena = 15.99;
            product1.dostepna_ilosc = 120;
            product1.opis = "Opis produktu";


            Product product2 = new Product();
            product2.nazwa = "produkt2";
            product2.cena = 102.99;
            product2.dostepna_ilosc = 120;
            product2.opis = "Bardzo długi i szczegółowy opis produktu niemieszczący się w jednym wierszu";


            Product product3 = new Product();
            product3.nazwa = "produkt3";
            product3.cena = 143.99;
            product3.dostepna_ilosc = 120;
            product3.opis = "Opis produktu";

            Product product4 = new Product();
            product4.nazwa = "produkt4";
            product4.cena = 26.99;
            product4.dostepna_ilosc = 120;
            product4.opis = "Opis produktu";

            Product product5 = new Product();
            product5.nazwa = "produkt5";
            product5.cena = 143.99;
            product5.dostepna_ilosc = 120;
            product5.opis = "Opis produktu";

            Product product6 = new Product();
            product6.nazwa = "produkt6";
            product6.cena = 75.99;
            product6.dostepna_ilosc = 120;
            product6.opis = "Opis produktu";

            Product product7 = new Product();
            product7.nazwa = "produkt7";
            product7.cena = 143.99;
            product7.dostepna_ilosc = 120;
            product7.opis = "Opis produktu";

            Product product8 = new Product();
            product8.nazwa = "produkt8";
            product8.cena = 1020.99;
            product8.dostepna_ilosc = 120;
            product8.opis = "Opis produktu";

            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
            products.Add(product6);
            products.Add(product7);
            products.Add(product8);

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
                    MessageBox.Show("Clicked on " + selectedProduct.nazwa/* + "\nQuantity: " + Quantity*/);
                    //Quantity = null;

                }, p => true));
            }
        }


    }
}
