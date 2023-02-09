using Application.Common;
using Domain.Interfaces;

namespace Application.Usecases;

public record RollDiceRequest(string GameId, string PlayerId) 
    : IRequest(GameId, PlayerId);

public class RollDiceUsecase: Usecase<RollDiceRequest>
{

    public RollDiceUsecase(IRepository repository, IEventBus<IDomainEvent> eventBus)
        : base(repository, eventBus)
    {
    }

    public override async Task ExecuteAsync(RollDiceRequest request)
    {
        //查
        var game = Repository.FindGameById(request.GameId);
        
        //改
        game.PlayerRollDice(request.PlayerId);
        
        //存
        Repository.Save(game);

        //推
        await EventBus.PublishAsync(game.DomainEvents);
    }
}