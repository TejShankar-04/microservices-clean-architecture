using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Orderno { get; set; }

        public string ItemNo { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = "PENDING";
    }
}
