using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public virtual ICollection<OrderItem> pozycje { get; set; }
        public User user { get; set; }
        public Address adres { get; set; }
        public DateTime data_zlozenia { get; set; }
        public OrderState Stan  { get; set; }
    }
}
