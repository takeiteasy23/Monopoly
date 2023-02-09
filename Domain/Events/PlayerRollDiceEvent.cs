using Domain.Interfaces;

namespace Domain.Events;

public record PlayerRollDiceEvent(string GameId): IDomainEvent(GameId);