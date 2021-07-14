using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Model
{
    class Cart
    {
        public virtual ICollection<OrderItem> pozycje { get; set; }

        public Cart()
        {
            pozycje = new List<OrderItem>();
        }
    }
}
