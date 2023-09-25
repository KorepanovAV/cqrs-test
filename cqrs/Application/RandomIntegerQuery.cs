using Cqrs.Common.Application.Query;

namespace Cqrs.Application;

public record struct RandomIntegerQuery(int Min, int Max)
    : IQuery<RandomIntegerQueryResult>;
