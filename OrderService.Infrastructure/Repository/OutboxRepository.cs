using ApplicaicationLayer.Interfaces;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Repository
{
    public class OutboxRepository: IOutboxRepository
    {
        private readonly OrderDbContext _orderDbContext;
        public OutboxRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Add(OutboxMessage message)
        {
            await _orderDbContext.outboxMessages.AddAsync(message);
            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<List<OutboxMessage>> GetUnprocessed()
        {
            return await _orderDbContext.outboxMessages.Where(x=>x.IsProcessed==false).ToListAsync();
        }

        public async Task Update(OutboxMessage message)
        {
            var outboxdetails = await _orderDbContext.outboxMessages.Where(x => x.IsProcessed == false).FirstOrDefaultAsync();

            if (outboxdetails != null)
            {
                outboxdetails.IsProcessed = message.IsProcessed;

                _orderDbContext.Entry(outboxdetails).State= EntityState.Modified ;
                await _orderDbContext.SaveChangesAsync();
            }
        }
    }
}
