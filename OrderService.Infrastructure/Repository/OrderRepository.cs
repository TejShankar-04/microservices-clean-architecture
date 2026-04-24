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
    public class OrderRepository: IOrderRepository
    {
        private readonly OrderDbContext _orderDbContext;

        public OrderRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Add(Order order)
        {
            await _orderDbContext.AddAsync(order);
            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<Order> GetorderByOrserNo(string orderNo)
        {

            var OrderDetail = await _orderDbContext.orders.Where(x => x.Orderno == orderNo).FirstOrDefaultAsync();
            return OrderDetail;
        }

        public async Task Update(Order order)
        {
            var OrderDetail = await _orderDbContext.orders.Where(x => x.Id == order.Id).FirstOrDefaultAsync();
            if (OrderDetail != null) 
            {
                OrderDetail.Status = order.Status;
                _orderDbContext.Entry(OrderDetail).State = EntityState.Modified;
            }
        }
    }
}
