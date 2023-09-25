using Cqrs.Common.Application.Command;

namespace Cqrs.Application;

public record struct GenerateRandomIntegersCommand(int Count)
    : ICommand<RandomIntegerGenerated>;
