using Confluent.Kafka;

namespace Kafka_Test_App.Lib.Kafka
{
    public sealed class Consumer
    {
        public void StartListening(CancellationToken cancellationToken)
        {
            var conf = new ConsumerConfig
            {
                GroupId = KafkaOptions.groupId,
                BootstrapServers = KafkaOptions.bootstrapServers,
                AutoOffsetReset = KafkaOptions.autoOffsetReset,
                EnableAutoCommit = KafkaOptions.enableAutoCommit,
                HeartbeatIntervalMs = KafkaOptions.heartbeatIntervalMs,
                SessionTimeoutMs = KafkaOptions.sessionTimeoutMs,
                MaxPollIntervalMs = KafkaOptions.maxPollIntervalMs // for example it is a fat consumer
            };

            using (var consumer = new ConsumerBuilder<string, string>(conf).Build())
            {
                consumer.Subscribe(KafkaOptions.topic);

                try
                {
                    while (true)
                    {
                        var consumerRsult = consumer.Consume(cancellationToken);
                        Console.WriteLine($"Message: {consumerRsult.Message.Value} " +
                            $"received from {consumerRsult.TopicPartitionOffset}");

                        consumer.Commit(consumerRsult);
                    }
                }
                catch (Exception)
                {
                    consumer.Close();
                }
            }
        }
    }
}