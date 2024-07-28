using Confluent.Kafka;

namespace Kafka_Test_App.Lib.Kafka
{
    public sealed class Producer
    {
        private readonly ProducerConfig config = new ProducerConfig
        {
            BootstrapServers = KafkaOptions.bootstrapServers,
            Acks = KafkaOptions.acks,
            BatchSize = KafkaOptions.bachSize,
            LingerMs = KafkaOptions.lingerMs
        };

        public async Task<string> SendToKafkaAsync(string message, string topic = KafkaOptions.topic)
        {
            using (var producer =
                 new ProducerBuilder<string, string>(config).Build())
            {
                try
                {
                    var result = await producer.ProduceAsync(topic, new Message<string, string>
                    {
                        Key = Guid.NewGuid().ToString(),
                        Value = message
                    });

                    return result.Value;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Oops, something went wrong: {e}");
                    return string.Empty;
                }
            }
        }
    }
}
