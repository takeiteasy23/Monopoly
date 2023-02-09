using Domain.Interfaces;

namespace Application.Common
{
    public interface IPresenter<TEvent> where TEvent : IDomainEvent
    {
    }
}