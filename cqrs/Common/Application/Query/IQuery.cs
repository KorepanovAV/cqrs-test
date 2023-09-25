namespace Cqrs.Common.Application.Query;

public interface IQuery<out TResult>
    where TResult : IResult { }
