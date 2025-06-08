namespace CocovoitAPI.Infrastructure.Configuration;

public record KafkaSettings
{
    public string BootstrapServers { get; init; } = default!;
    public string TopicReservationCreated { get; init; } = default!;
    public string ClientId { get; init; } = "producer-api";
}