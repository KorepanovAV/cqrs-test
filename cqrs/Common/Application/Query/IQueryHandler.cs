using System.Threading.Tasks;

namespace Cqrs.Common.Application.Query;

public interface IQueryHandler<TResult>
    where TResult : IResult
{
    Task<TResult> HandleAsync(IQuery<TResult> query);

    TResult Handle(IQuery<TResult> query);
}

public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TResult>
    where TQuery : IQuery<TResult>
    where TResult : IResult
{
    public Task<TResult> HandleAsync(IQuery<TResult> query)
    {
        return this.HandleAsync((TQuery)query);
    }

    public TResult Handle(IQuery<TResult> query)
    {
        return this.Handle((TQuery)query);
    }

    protected abstract Task<TResult> HandleAsync(TQuery query);

    protected abstract TResult Handle(TQuery query);
}
