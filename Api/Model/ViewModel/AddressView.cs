using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.ViewModel
{
    public class AddressView
    {
        public long id { get; set; }
        public string ulica { get; set; }
        public long nr { get; set; }
        public long nr_mieszkania { get; set; }
        public string kod_pocztowy { get; set; }
        public string miejscowosc { get; set; }

        public AddressView(Address address)
        {
            id = address.id;
            ulica = address.ulica;
            nr = address.nr;
            nr_mieszkania = address.nr_mieszkania;
            kod_pocztowy = address.kod_pocztowy;
            miejscowosc = address.miejscowosc;
        }
    }
}
