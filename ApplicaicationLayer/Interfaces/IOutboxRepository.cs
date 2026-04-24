using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicaicationLayer.Interfaces
{
    public interface IOutboxRepository
    {
        Task Add(OutboxMessage message);
        Task<List<OutboxMessage>> GetUnprocessed();
        Task Update(OutboxMessage message);
    }
}
