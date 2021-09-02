using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Model
{
    class ProductCart
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
    }
}
