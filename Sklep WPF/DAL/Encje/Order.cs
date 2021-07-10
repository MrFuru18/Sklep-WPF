using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Model
{
    class Order
    {
        public long id { get; set; }
        public virtual ICollection<OrderItem> pozycje { get; set; }
        public Address adres { get; set; }
        public DateTime data_zlozenia { get; set; }
    }
}
