using Domain.Interfaces;

namespace Application.Common;

public abstract class Usecase<TRequest> where TRequest : IRequest
{
    protected IRepository Repository { get; }
    protected IEventBus<IDomainEvent> EventBus { get; }

    public Usecase(IRepository repository, IEventBus<IDomainEvent> eventBus)
    {
        Repository = repository;
        EventBus = eventBus;
    }
    
    public abstract Task ExecuteAsync(TRequest request);
}