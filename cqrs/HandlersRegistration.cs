using Cqrs.Application;
using Cqrs.Common.Application.Command;
using Cqrs.Common.Application.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Cqrs;

public static class HandlersRegistration
{
    public static void RegisterHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<ICommandHandler<RandomIntegerGenerated>, GenerateRandomIntegersCommandHandler>()
            .AddTransient<IQueryHandler<RandomIntegerQueryResult>, RandomIntegerQueryHandler>();
    }
}
