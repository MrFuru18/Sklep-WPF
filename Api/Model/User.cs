using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        public virtual ICollection<Address> adresy { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
    }
}
