using Payment.ApplicationLayer.Interfaces;
using Payment.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repository
{
    public class PaymentCreate: IPaymentCreate
    {
        private readonly PaymentDbClass _paymentDbClass;

        public PaymentCreate(PaymentDbClass paymentDbClass)
        {
            _paymentDbClass = paymentDbClass;
        }

        public async Task Addpayment(Paymentclass paymentclass)
        {
            await _paymentDbClass.payments.AddAsync(paymentclass);
            await _paymentDbClass.SaveChangesAsync();
        }

    }
}
