using Cqrs.Common.Application.Query;

namespace Cqrs.Application;

public record MemoizedRandomIntegerQuery(string DevelopmentId)
    : IQuery<MemoizedRandomIntergerQueryResult>;
