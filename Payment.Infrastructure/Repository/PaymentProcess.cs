using Confluent.Kafka;
using Payment.ApplicationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repository
{
    public class PaymentProcess: IPaymrntProcess
    {

        private readonly ProducerConfig _producerConfig;

        public PaymentProcess()
        {
            _producerConfig = new ProducerConfig
            {
                BootstrapServers = "kafka:9092"
            };
        }

        public async Task ExcuteAsync(string topic, string messag)
        {
            using var producers = new ProducerBuilder<Null, string>(_producerConfig).Build();

            await producers.ProduceAsync(topic, new Message<Null, string> { Value = messag });
        }
    }
}
