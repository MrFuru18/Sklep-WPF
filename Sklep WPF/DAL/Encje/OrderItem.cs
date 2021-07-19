using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Model
{
    class OrderItem
    {
        public long ilosc { get; set; }
        public double cena_1 { get; set; }
        public Guid produkt_id { get; set; }
    }
}
