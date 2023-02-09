using Domain.Interfaces;

namespace Application.Common;

public interface IEventBus<TEvent> where TEvent : IDomainEvent
{
    public Task PublishAsync(IEnumerable<TEvent> events);
}