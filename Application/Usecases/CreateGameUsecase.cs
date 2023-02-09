using Application.Common;
using Domain;
using Domain.Events;
using Domain.Interfaces;

namespace Application.Usecases;

public record CreateGameRequest(string GameId, string PlayerId) : IRequest(GameId, PlayerId);
public class CreateGameUsecase : Usecase<CreateGameRequest>
{
    public CreateGameUsecase(IRepository repository, IEventBus<IDomainEvent> eventBus) : base(repository, eventBus)
    {
    }

    public override async Task ExecuteAsync(CreateGameRequest request)
    {
        // 查
        // 改
        Game game = new(request.GameId);

        // 存
        string id = Repository.Save(game);
        List<IDomainEvent> domainEvents = game.DomainEvents.ToList();
        domainEvents.Add(new GameCreatedEvent(id));

        // 推
        await EventBus.PublishAsync(domainEvents);
    }
}
