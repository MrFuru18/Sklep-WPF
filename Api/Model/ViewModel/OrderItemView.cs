using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.ViewModel
{
    public class OrderItemView
    {
        public long ilosc { get; set; }
        public double cena_1 { get; set; }
        public Guid produkt_id { get; set; }

        public OrderItemView(OrderItem item)
        {
            ilosc = item.ilosc;
            cena_1 = item.cena_1;
            produkt_id = item.produkt.id;
        }
        public OrderItemView() { }
    }
}