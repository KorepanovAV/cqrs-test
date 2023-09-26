using Cqrs.Common.Application.Query;

namespace Cqrs.Application;

public record RandomIntegerQuery(int Min, int Max)
    : IQuery<RandomIntegerQueryResult>;
