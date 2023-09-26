using Cqrs.Common.Application.Command;

namespace Cqrs.Common.Application;

public interface IEventBus
{
    void Push<TEvent>(TEvent @event) where TEvent : IEvent;
}
