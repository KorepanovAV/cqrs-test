using Cqrs.Common.Application.Query;

namespace Cqrs.Application;

public record MemoizedRandomIntergerQueryResult(int Value) : IResult;
