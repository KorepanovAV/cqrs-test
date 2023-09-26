using System.Reflection.Metadata;

namespace Cqrs.Common.Application.Command;

interface IEventHandler<TEvent>
    where TEvent : IEvent
{
    void Handle(IEventBus eventBus, TEvent @event);
}
