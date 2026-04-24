using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicaicationLayer.Interfaces
{
    public interface IOrderRepository
    {
        Task Add(Order order);
        Task<Order> GetorderByOrserNo(string orderNo);

        Task Update(Order order);
    }
}
