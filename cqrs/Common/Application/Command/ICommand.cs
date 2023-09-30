namespace Cqrs.Common.Application.Command;

public interface ICommand<out TEvent>
    where TEvent : IEvent
{
    string DevelopmentId { get; }
}
