using ApplicaicationLayer.DTOs;
using ApplicaicationLayer.Handlers;
using ApplicaicationLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICreateOrderHandler _handler;

        public OrderController(ICreateOrderHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest orderRequest)
        {
            if (orderRequest == null) { throw new Exception("Request is null"); }
            await _handler.Handle(orderRequest);
            return Ok("Order Created");
        }
    }
}
