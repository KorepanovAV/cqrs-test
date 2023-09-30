using System.Collections.Generic;
using System.Threading.Tasks;
using Cqrs.Common.Application;
using Cqrs.Common.Application.Command;
using Cqrs.Common.Application.Query;
using Cqrs.Common.Domain;

namespace Cqrs.Common.Infrastructure;

internal class CommandQueryDispatcher : ICommandQueryDispatcher
{
    // TODO: AnonymousScopeAttribute, DisposeScopeAttribute

    private readonly DevelopmentScopeProvider _scopeProvider;

    private readonly IEventBus _eventBus;

    public IEnumerable<TEvent> Handle<TEvent>(ICommand<TEvent> command)
        where TEvent : IEvent
    {
        Development.AssignId(command.DevelopmentId);
        var scope = _scopeProvider.Get(command.DevelopmentId);
        var handler = scope.GetService<ICommandHandler<TEvent>>();
        return handler.Handle(_eventBus, command);
    }

    public IAsyncEnumerable<TEvent> HandleAsync<TEvent>(ICommand<TEvent> command)
        where TEvent : IEvent
    {
        Development.AssignId(command.DevelopmentId);
        var scope = _scopeProvider.Get(command.DevelopmentId);
        var handler = scope.GetService<ICommandHandler<TEvent>>();
        return handler.HandleAsync(_eventBus, command);
    }

    public TResult Handle<TResult>(IQuery<TResult> query)
        where TResult : IResult
    {
        Development.AssignId(query.DevelopmentId);
        var scope = _scopeProvider.Get(query.DevelopmentId);
        var handler = scope.GetService<IQueryHandler<TResult>>();
        return handler.Handle(query);
    }

    public ValueTask<TResult> HandleAsync<TResult>(IQuery<TResult> query)
        where TResult : IResult
    {
        Development.AssignId(query.DevelopmentId);
        var scope = _scopeProvider.Get(query.DevelopmentId);
        var handler = scope.GetService<IQueryHandler<TResult>>();
        return handler.HandleAsync(query);
    }

    public CommandQueryDispatcher(DevelopmentScopeProvider scopeProvider, IEventBus eventBus)
    {
        _scopeProvider = scopeProvider;
        _eventBus = eventBus;
    }
}
