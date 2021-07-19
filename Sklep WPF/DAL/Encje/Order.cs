using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Model
{
    class Order
    {
        public Guid id { get; set; }
        public virtual ICollection<OrderItem> pozycje { get; set; }
        public long adres_id { get; set; }
        public DateTime data_zlozenia { get; set; }
        public OrderState Stan { get; set; }
    }
}
