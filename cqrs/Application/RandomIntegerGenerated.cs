using Cqrs.Common.Application.Command;

namespace Cqrs.Application;

public record struct RandomIntegerGenerated(int Value) : IEvent;
