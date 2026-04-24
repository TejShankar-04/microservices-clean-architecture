using ApplicaicationLayer.DTOs;
using ApplicaicationLayer.Handlers;
using ApplicaicationLayer.Interfaces;
using DomainLayer.Entities;
using Moq;
using Xunit;

public class OrderHandlerTests
{
    [Fact]
    public async Task Should_Create_Order_Successfully()
    {
        var mockRepo = new Mock<IOrderRepository>();
        var mockRepo1 = new Mock<IOutboxRepository>();

        var handler = new CreateOrderHandler(mockRepo.Object, mockRepo1.Object);

        var request = new CreateOrderRequest
        {
            OrderNo = "ORD123",
            Amount = 100,
            ItemNo = "ITEM1"
        };

        await handler.Handle(request);

        mockRepo.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
    }
}