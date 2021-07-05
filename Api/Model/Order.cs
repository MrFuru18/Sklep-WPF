using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Order
    {
        [Key]
        public long id { get; set; }
        public virtual ICollection<OrderItem> pozycje { get; set; }
        public User user { get; set; }
        public Address adres { get; set; }
        public DateTime data_zlozenia { get; set; }
    }
}
