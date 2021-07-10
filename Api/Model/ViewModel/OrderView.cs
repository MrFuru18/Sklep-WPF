using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.ViewModel
{
    public class OrderView
    {
        public long id { get; set; }
        public virtual ICollection<OrderItemView> pozycje { get; set; }
        public long adres_id { get; set; }
        public DateTime data_zlozenia { get; set; }
        public OrderState Stan { get; set; }

        public OrderView(Order order)
        {
            id = order.id;
            pozycje = new List<OrderItemView>();
            foreach(OrderItem x in order.pozycje)
            {
                pozycje.Add(new OrderItemView(x));
            }
            adres_id = order.adres.id;
            data_zlozenia = order.data_zlozenia;
            Stan = order.Stan;
        }
    }
}
