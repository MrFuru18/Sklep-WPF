using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Model
{
    class Product
    {
        public Guid id { get; set; }
        public string nazwa { get; set; }
        public double cena { get; set; }
        public long dostepna_ilosc { get; set; }
        public string opis { get; set; }
    }
}
