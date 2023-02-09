using Application.Common;
using Domain.Events;
using Domain.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Server.Hubs;

namespace Server;

public class EventBus : IEventBus<IDomainEvent>
{
    private readonly IHubContext<MonopolyHub, IMonopolyResponses> _hubContext;

    public EventBus(IHubContext<MonopolyHub, IMonopolyResponses> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task PublishAsync(IEnumerable<IDomainEvent> events)
    {
        // 不同的事件，推送给不同的客戶端
        // 若事件的內容物相同，SignalR會認為是同一種型態(跨網路傳輸的資料，不會有型態的資訊)
        await _hubContext.Clients.All.GameCreatedEvent(events.First());
    }
}