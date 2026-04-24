using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Repository
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext>options):base(options)
        {
            
        }

         public DbSet<Order> orders { get; set; }
        public DbSet<OutboxMessage> outboxMessages { get; set; }
    }
}
