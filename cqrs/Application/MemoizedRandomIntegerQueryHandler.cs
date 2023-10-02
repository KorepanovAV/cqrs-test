using System.Threading.Tasks;
using Cqrs.Common.Application.Query;

namespace Cqrs.Application;

public class MemoizedRandomIntegerQueryHandler
: IQueryHandler<MemoizedRandomIntergerQueryResult>
{
    private readonly State state;

    public ValueTask<MemoizedRandomIntergerQueryResult> HandleAsync(IQuery<MemoizedRandomIntergerQueryResult> query)
    {
        return new ValueTask<MemoizedRandomIntergerQueryResult>(new MemoizedRandomIntergerQueryResult(state.Value));
    }

    public MemoizedRandomIntergerQueryResult Handle(IQuery<MemoizedRandomIntergerQueryResult> query)
    {
        return new MemoizedRandomIntergerQueryResult(state.Value);
    }

    public MemoizedRandomIntegerQueryHandler(State state)
    {
        this.state = state;
    }
}
