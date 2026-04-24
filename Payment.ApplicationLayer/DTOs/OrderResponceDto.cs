using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.ApplicationLayer.DTOs
{
    public class OrderResponceDto
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
    }
}
