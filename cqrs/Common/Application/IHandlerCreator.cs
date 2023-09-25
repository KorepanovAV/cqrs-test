using Cqrs.Common.Application.Command;
using Cqrs.Common.Application.Query;

namespace Cqrs.Common.Application;

public interface IHandlerCreator
{
    public ICommandHandler<TEvent> Create<TEvent>(ICommand<TEvent> command)
        where TEvent : IEvent;

    public IQueryHandler<TResult> Create<TResult>(IQuery<TResult> query)
        where TResult : IResult;
}
