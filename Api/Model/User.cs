using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class User
    {
        [Key]
        public long id { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string nr_tel { get; set; }
        public virtual ICollection<Address> adresy { get; set; }
        public string token { get; set; }
    }
}
