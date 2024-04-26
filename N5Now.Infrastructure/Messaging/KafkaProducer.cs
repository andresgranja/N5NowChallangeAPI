using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace N5Now.Infrastructure.Messaging
{
    public class KafkaProducer
    {
        private readonly ProducerConfig _config;

        public KafkaProducer(string bootstrapServers)
        {
            _config = new ProducerConfig { BootstrapServers = bootstrapServers };
        }

        public async Task ProduceMessageAsync<T>(string topic, T message)
        {
            using (var producer = new ProducerBuilder<Null, string>(_config)
                .Build())
            {
                try
                {
                    var serializedMessage = JsonConvert.SerializeObject(message);
                    var deliveryReport = await producer.ProduceAsync(topic, new Message<Null, string> { Value = serializedMessage });

                    Console.WriteLine($"Message sent to topic {deliveryReport.Topic}, partition {deliveryReport.Partition}, offset {deliveryReport.Offset}");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Failed to deliver message: {e.Error.Reason}");
                    throw;
                }
            }
        }
    }
}
