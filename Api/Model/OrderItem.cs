using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class OrderItem
    {
        [Key]
        public long id { get; set; }
        public long ilosc { get; set; }
        public double cena_1 { get; set; }
        public Product produkt { get; set; }
    }
}
