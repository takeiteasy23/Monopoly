using Domain.Events;
using Domain.Interfaces;

namespace Server.Hubs;

public interface IMonopolyResponses
{
    Task GameCreatedEvent(IDomainEvent domainEvent);
}