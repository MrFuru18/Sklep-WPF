using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Model
{
    class OrderHistory
    {
        public Guid id { get; set; }
        public virtual ICollection<OrderHistoryItem> pozycje { get; set; }
        public Guid adres_id { get; set; }
        public string ulica { get; set; }
        public long nr { get; set; }
        public long nr_mieszkania { get; set; }
        public string kod_pocztowy { get; set; }
        public string miejscowosc { get; set; }
        public DateTime data_zlozenia { get; set; }
        public OrderState Stan { get; set; }

    }
}
