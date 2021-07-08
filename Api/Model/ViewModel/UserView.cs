using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.ViewModel
{
    public class UserView
    {
        public string login { get; set; }
        public string email { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string nr_tel { get; set; }
        public virtual ICollection<Address> adresy { get; set; }
        public string token { get; set; }
    }
}
