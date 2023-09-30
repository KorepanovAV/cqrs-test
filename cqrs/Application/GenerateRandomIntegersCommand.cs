using Cqrs.Common.Application.Command;

namespace Cqrs.Application;

public record GenerateRandomIntegersCommand(int Count, string DevelopmentId)
    : ICommand<RandomIntegerGenerated>;
