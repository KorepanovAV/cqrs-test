using System.Threading.Tasks;

namespace Cqrs.Common.Application.Query;

public interface IQueryHandler<TResult>
    where TResult : IResult
{
    ValueTask<TResult> HandleAsync(IQuery<TResult> query);

    TResult Handle(IQuery<TResult> query);
}

public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TResult>
    where TQuery : class, IQuery<TResult>
    where TResult : IResult
{
    public ValueTask<TResult> HandleAsync(IQuery<TResult> query)
    {
        return this.HandleAsync((TQuery)query);
    }

    public TResult Handle(IQuery<TResult> query)
    {
        return this.Handle((TQuery)query);
    }

    protected abstract ValueTask<TResult> HandleAsync(TQuery query);

    protected abstract TResult Handle(TQuery query);
}
