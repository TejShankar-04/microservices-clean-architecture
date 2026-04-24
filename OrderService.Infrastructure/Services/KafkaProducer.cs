using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Services
{
    public class KafkaProducer
    {
        private readonly IProducer<Null,string> _producer;

        public KafkaProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "kafka:9092"
                //BootstrapServers = "localhost:9092"
            };

            _producer = new ProducerBuilder<Null,string>(config).Build();
        }

        public async Task Send(string topic, string message)
        {
            await _producer.ProduceAsync(topic, new Message<Null, string>
            {
                Value = message
            });
        }
    }
}
