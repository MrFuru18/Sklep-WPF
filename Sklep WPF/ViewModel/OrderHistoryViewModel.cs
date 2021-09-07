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
        public List<Address> addresses { get; set; }
        public List<Product> products { get; set; }
        public List<OrderHistory> orderHistory { get; set; }

        public OrderHistoryViewModel()
        {
            orders = OrderRepo.getAllOrders().Result;
            addresses = AddressRepo.getAllAddresses().Result;
            products = ProductRepo.getAllProtucts().Result;

            orderHistory = new List<OrderHistory>();

            foreach (var order in orders)
            {
                List<OrderHistoryItem> orderHistoryItems = new List<OrderHistoryItem>();
                foreach (var pozycja in order.pozycje)
                {
                    OrderHistoryItem item = new OrderHistoryItem()
                    {
                        produkt_id = pozycja.produkt_id,
                        ilosc = pozycja.ilosc,
                        cena_1 = pozycja.cena_1
                    };
                    foreach (var product in products)
                    {
                        if (product.id == item.produkt_id)
                            item.nazwa = product.nazwa;
                    }
                    orderHistoryItems.Add(item);
                }
                OrderHistory _order = new OrderHistory()
                {
                    id = order.id,
                    pozycje = orderHistoryItems,
                    adres_id = order.adres_id,
                    data_zlozenia = order.data_zlozenia,
                    Stan = order.Stan
                };
                foreach (var address in addresses)
                {
                    if (address.id == _order.adres_id)
                    {
                        _order.ulica = address.ulica;
                        _order.nr = address.nr;
                        _order.nr_mieszkania = address.nr_mieszkania;
                        _order.kod_pocztowy = address.kod_pocztowy;
                        _order.miejscowosc = address.miejscowosc;
                    }
                }
                orderHistory.Add(_order);
            }
            
        }

    }
}
