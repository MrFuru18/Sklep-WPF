using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.ViewModel
{
    public class ProductView
    {
        public Guid id { get; set; }
        public string nazwa { get; set; }
        public double cena { get; set; }
        public long dostepna_ilosc { get; set; }
        public string opis { get; set; }

        public ProductView(Product product)
        {
            id = product.id;
            nazwa = product.nazwa;
            cena = product.cena;
            dostepna_ilosc = product.dostepna_ilosc;
            opis = product.opis;
        }
    }
}
