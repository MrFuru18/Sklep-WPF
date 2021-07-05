using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Product
    {
        [Key]
        public long id { get; set; }
        public string nazwa { get; set; }
        public double cena { get; set; }
        public long dostepna_ilosc { get; set; }
        public string opis { get; set; }
    }
}
