using System;
using Cqrs.Common.Application;
using Cqrs.Common.Application.Command;
using Microsoft.Extensions.DependencyInjection;

namespace Cqrs.Common.Infrastructure;

public class EventBus : IEventBus
{
    private readonly IServiceProvider _serviceProvider;

    public EventBus(IServiceProvider provider)
    {
        this._serviceProvider = provider;
    }

    public void Push<TEvent>(TEvent @event) where TEvent : IEvent
    {
        var handlers = this._serviceProvider.GetServices<IEventHandler<TEvent>>();
        foreach (var handler in handlers)
        {
            handler.Handle(this, @event);
        }
    }
}
