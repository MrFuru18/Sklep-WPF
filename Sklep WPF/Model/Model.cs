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
            List<Product> x = ProductRepo.getAllProtucts();
            Products = ProductRepo.getAllProtucts();
        }
    }
}
