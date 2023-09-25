using System.Collections.Generic;
using System.Threading.Tasks;
using Cqrs.Common.Application.Command;
using Cqrs.Common.Application.Query;

namespace Cqrs.Common.Application;

public interface IHandler
{
    public IEnumerable<TEvent> Handle<TEvent>(ICommand<TEvent> command)
        where TEvent : IEvent;

    public IAsyncEnumerable<TEvent> HandleAsync<TEvent>(ICommand<TEvent> command)
        where TEvent : IEvent;

    public TResult Handle<TResult>(IQuery<TResult> query)
        where TResult : IResult;

    public Task<TResult> HandleAsync<TResult>(IQuery<TResult> query)
        where TResult : IResult;
}
