using Domain.Interfaces;

namespace Domain.Events;

public record GameCreatedEvent(string GameId) : IDomainEvent(GameId);