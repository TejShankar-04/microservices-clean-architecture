using Microsoft.EntityFrameworkCore;
using Payment.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repository
{
    public class PaymentDbClass:DbContext
    {
        public PaymentDbClass(DbContextOptions<PaymentDbClass>options):base(options)
        {
            
        }
        public DbSet<Paymentclass> payments { get; set; }
    }
}
