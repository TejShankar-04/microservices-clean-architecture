using ApplicaicationLayer.DTOs;
using ApplicaicationLayer.Interfaces;
using DomainLayer.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicaicationLayer.Handlers
{
    public class CreateOrderHandler: ICreateOrderHandler
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IOutboxRepository _outboxRepo;

        public CreateOrderHandler(IOrderRepository orderRepo, IOutboxRepository outboxRepo)
        {
            _orderRepo = orderRepo;
            _outboxRepo = outboxRepo;
        }

        public async Task Handle(CreateOrderRequest orderRequest)
        {
            if (orderRequest == null) { throw new Exception("Request is null 2"); }
            var existingOrder = await _orderRepo.GetorderByOrserNo(orderRequest.OrderNo);
            if (existingOrder != null)
                throw new Exception("Order already exists");

            var Orders = new Order();
            Orders.Orderno = orderRequest.OrderNo;
            Orders.Amount = orderRequest.Amount;
            Orders.ItemNo = orderRequest.ItemNo;
            Orders.Status = "pending";



            await _orderRepo.Add(Orders);

            var eventData = new OrderCreatedEvent
            {
                OrderId = Orders.Id,
                Amount = Orders.Amount
            };
            if(eventData == null) { throw new Exception("Request is null"); }
            await _outboxRepo.Add(new OutboxMessage
            {
                EventType = "OrderCreated",
                Payload = JsonConvert.SerializeObject(eventData)
            });
        }
    }
}
