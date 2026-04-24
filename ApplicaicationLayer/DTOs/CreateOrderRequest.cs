using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicaicationLayer.DTOs
{
    public class CreateOrderRequest
    {
        public string OrderNo { get; set; }

        public decimal Amount { get; set; }

        public string ItemNo { get; set; }
    }
}
