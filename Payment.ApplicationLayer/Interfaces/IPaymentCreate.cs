using Payment.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.ApplicationLayer.Interfaces
{
    public interface IPaymentCreate
    {
        Task Addpayment(Paymentclass paymentclass);
    }
}
