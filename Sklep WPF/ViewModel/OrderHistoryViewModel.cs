using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_WPF.DAL.Repozytoria;
using Sklep_WPF.Model;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    class OrderHistoryViewModel : ViewModelBase
    {
        public List<Order> orders { get; set; }

        public OrderHistoryViewModel()
        {
            orders = OrderRepo.getAllOrders().Result;
        }

    }
}
