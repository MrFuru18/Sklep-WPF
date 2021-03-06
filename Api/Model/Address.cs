using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string ulica { get; set; }
        public long nr { get; set; }
        public long nr_mieszkania { get; set; }
        public string kod_pocztowy { get; set; }
        public string miejscowosc { get; set; }
    }
}
