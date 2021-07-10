using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class User : IdentityUser
    {
        public virtual ICollection<Address> adresy { get; set; }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long id { get; set; }
        //public string login { get; set; }
        //public string email { get; set; }
        //public string haslo { get; set; }
        //public string imie { get; set; }
        //public string nazwisko { get; set; }
        //public string nr_tel { get; set; }
        //public virtual ICollection<Address> adresy { get; set; }
        //public string token { get; set; }
    }
}
