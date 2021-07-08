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
    }
}
