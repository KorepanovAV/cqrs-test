using System.Collections.Generic;

namespace Cqrs.Common.Application.Command;

public interface ICommandHandler<TEvent>
    where TEvent : IEvent
{
    IAsyncEnumerable<TEvent> HandleAsync(IEventBus eventBus, ICommand<TEvent> command);

    IEnumerable<TEvent> Handle(IEventBus eventBus, ICommand<TEvent> command);
}

public abstract class CommandHandler<TCommand, TEvent> : ICommandHandler<TEvent>
    where TCommand : class, ICommand<TEvent>
    where TEvent : IEvent
{
    public async IAsyncEnumerable<TEvent> HandleAsync(IEventBus eventBus, ICommand<TEvent> command)
    {
        await foreach (var @event in this.HandleAsync((TCommand)command))
        {
            eventBus.Push(@event);
            yield return @event;
        }
    }

    public IEnumerable<TEvent> Handle(IEventBus @eventBus, ICommand<TEvent> command)
    {
        foreach (var @event in this.Handle((TCommand)command))
        {
            eventBus.Push(@event);
            yield return @event;
        }
    }

    protected abstract IAsyncEnumerable<TEvent> HandleAsync(TCommand command);

    protected abstract IEnumerable<TEvent> Handle(TCommand command);
}
