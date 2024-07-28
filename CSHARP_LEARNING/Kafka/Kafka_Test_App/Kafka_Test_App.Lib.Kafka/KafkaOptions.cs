using Confluent.Kafka;

namespace Kafka_Test_App.Lib.Kafka
{
    public class KafkaOptions
    {
        internal const string topic = "ReplicedTopic-test";
        internal const AutoOffsetReset autoOffsetReset = AutoOffsetReset.Earliest;
        internal const string bootstrapServers = "localhost:9092";
        internal const string groupId = "st_consumer_group";
        internal const Acks acks = Acks.All;
        internal const int bachSize = 50;
        internal const int lingerMs = 10;
        internal const bool enableAutoCommit = false;
        internal const int heartbeatIntervalMs = 10_000;
        internal const int sessionTimeoutMs = 40_000;
        internal const int maxPollIntervalMs = 60_000;
    }
}
