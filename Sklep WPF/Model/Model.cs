using Sklep_WPF.DAL.Repozytoria;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Model
{
    class Model
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Address> Addresses { get; set; } = new ObservableCollection<Address>();
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        public User LoggedInAccount { get; set; }

        public Model()
        {
            getProducts();
        }

        public async void getProducts()
        {
            List<Product> products = await ProductRepo.getAllProtucts();
            foreach (var x in products)
            {
                Products.Add(x);
            }
        }

        public async void getAddresses()
        {
            List<Address> addresses = await AddressRepo.getAllAddresses();
            foreach (var x in addresses)
            {
                Addresses.Add(x);
            }
        }

        public async void getOrders()
        {
            if(LoggedInAccount!=null)
            {
                List<Order> orders = await OrderRepo.getAllOrders();
                foreach (var x in orders)
                {
                    Orders.Add(x);
                }
            }
        }

        public async void Login(LoginModel loginModel)
        {
            LoggedInAccount = await UserRepo.Login(loginModel);
        }
    }
}
