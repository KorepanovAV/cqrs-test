using System.Collections.Generic;

namespace Cqrs.Common.Application.Command;

public interface ICommandHandler<TEvent>
    where TEvent : IEvent
{
    IAsyncEnumerable<TEvent> HandleAsync(ICommand<TEvent> command);

    IEnumerable<TEvent> Handle(ICommand<TEvent> command);
}

public abstract class CommandHandler<TCommand, TEvent> : ICommandHandler<TEvent>
    where TCommand : ICommand<TEvent>
    where TEvent : IEvent
{
    public IAsyncEnumerable<TEvent> HandleAsync(ICommand<TEvent> command)
    {
        return this.HandleAsync((TCommand)command);
    }

    public IEnumerable<TEvent> Handle(ICommand<TEvent> command)
    {
        return this.Handle((TCommand)command);
    }

    protected abstract IAsyncEnumerable<TEvent> HandleAsync(TCommand command);

    protected abstract IEnumerable<TEvent> Handle(TCommand command);
}
