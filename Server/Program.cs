using Application;
using Application.Common;
using Domain.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Server;
using Server.Hubs;
using Server.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRepository, InMemoryRepository>();
builder.Services.AddSingleton<IEventBus<IDomainEvent>, EventBus>();
builder.Services.AddMonopolyApplication();
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});

var app = builder.Build();

app.MapHub<MonopolyHub>("/monopoly");

app.Run();