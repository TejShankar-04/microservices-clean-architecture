using ApplicaicationLayer.DTOs;
using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Payment.ApplicationLayer.DTOs;
using Payment.ApplicationLayer.Interfaces;
using Payment.DomainLayer.Entities;
using Payment.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Payment.Infrastructure
{
    public class PaymentConsumerService:BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<PaymentConsumerService> _logger;
        
        public PaymentConsumerService(IServiceScopeFactory serviceScopeFactory, ILogger<PaymentConsumerService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "kafka:9092",
                GroupId = "payment-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("order-topic");

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var result = consumer.Consume(cancellationToken);
                    Console.WriteLine("RAW: " + result.Message.Value);
                    if (result?.Message == null)
                        continue;

                    var order = JsonSerializer.Deserialize<OrderResponceDto>(result.Message.Value);

                    if (order == null)
                    {
                        _logger.LogWarning("Invalid message received");
                        continue;
                    }

                    using var scope = _serviceScopeFactory.CreateScope();

                    var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentCreate>();
                    var producer = scope.ServiceProvider.GetRequiredService<IPaymrntProcess>();

                    var status = order.Amount > 100 ? "Failed" : "Complete";

                    var payment = new Paymentclass
                    {
                        OrderId = order.OrderId,
                        Amount = order.Amount,
                        Status = status
                    };

                    await paymentService.Addpayment(payment);

                    var response = JsonSerializer.Serialize(new paymentStatusResponce
                    {
                        orderId = order.OrderId,
                        status = status
                    });

                    _logger.LogInformation("Sending to Kafka: {response}", response);

                    await producer.ExcuteAsync("payment-topic", response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in PaymentConsumerService");
            }
            finally
            {
                consumer.Close();
            }
        }

    }
}
