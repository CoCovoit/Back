using CocovoitAPI.Application.Bus;
using CocovoitAPI.Infrastructure.Configuration;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace CocovoitAPI.Infrastructure.Messaging;

public class KafkaEventBus : IEventBus, IDisposable
{
    private readonly IProducer<string?, string> _producer;

    public KafkaEventBus(IOptions<KafkaSettings> options)
    {
        var cfg = options.Value;
        var config = new ProducerConfig
        {
            BootstrapServers = cfg.BootstrapServers,
            ClientId = cfg.ClientId,
            Acks = Acks.All
        };
        _producer = new ProducerBuilder<string?, string>(config).Build();
    }

    public Task PublishAsync(string topic, string? key, string value, CancellationToken ct = default) =>
        _producer.ProduceAsync(topic, new Message<string?, string> { Key = key, Value = value }, ct);

    public void Dispose() => _producer.Dispose();
}