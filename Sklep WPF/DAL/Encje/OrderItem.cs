using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Model
{
    class OrderItem //w koszyku lub zamówieniu
    {
        public long id { get; set; }
        public long ilosc { get; set; }
        public double cena_1 { get; set; }
        public Product produkt { get; set; }
    }
}
