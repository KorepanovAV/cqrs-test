using Cqrs.Common.Application.Query;

namespace Cqrs.Application;

public record struct RandomIntegerQueryResult(int Value)
    : IResult;
