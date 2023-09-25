using System;
using System.Threading.Tasks;
using Cqrs.Common.Application.Query;

namespace Cqrs.Application;

public class RandomIntegerQueryHandler : QueryHandler<RandomIntegerQuery, RandomIntegerQueryResult>
{
    protected override ValueTask<RandomIntegerQueryResult> HandleAsync(RandomIntegerQuery query)
    {
        var rand = new Random();
        return ValueTask.FromResult(new RandomIntegerQueryResult(rand.Next(query.Min, query.Max)));
    }

    protected override RandomIntegerQueryResult Handle(RandomIntegerQuery query)
    {
        var rand = new Random();
        return new RandomIntegerQueryResult(rand.Next(query.Min, query.Max));
    }
}
