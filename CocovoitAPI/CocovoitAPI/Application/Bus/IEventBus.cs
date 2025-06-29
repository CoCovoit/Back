namespace CocovoitAPI.Application.Bus;

public interface IEventBus
{
    Task PublishAsync(string topic, string? key, string value, CancellationToken ct = default);
}