using System;
using Cqrs.Common.Application;
using Cqrs.Common.Application.Command;
using Cqrs.Common.Application.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Cqrs.Common.Infrastructure;

public class HandlerCreator : IHandlerCreator
{
    private readonly IServiceProvider _serviceProvider;

    public ICommandHandler<TEvent> Create<TEvent>(ICommand<TEvent> command)
        where TEvent : IEvent
    {
        return this._serviceProvider.GetService<ICommandHandler<TEvent>>();
    }

    public IQueryHandler<TResult> Create<TResult>(IQuery<TResult> query)
        where TResult : IResult
    {
        return this._serviceProvider.GetService<IQueryHandler<TResult>>();
    }

    public HandlerCreator(IServiceProvider provider)
    {
        this._serviceProvider = provider;
    }
}
