using ApplicaicationLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderService.Infrastructure
{
    public class OutboxProcessor : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public OutboxProcessor(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceScopeFactory.CreateScope();

                var _repo = scope.ServiceProvider.GetRequiredService<IOutboxRepository>();
                var _producer = scope.ServiceProvider.GetRequiredService<KafkaProducer>();

                var messages = await _repo.GetUnprocessed();

                foreach (var msg in messages)
                {
                    await _producer.Send("order-topic", msg.Payload);

                    msg.IsProcessed = true;
                    await _repo.Update(msg);
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
