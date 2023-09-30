using Cqrs.Application;
using Cqrs.Common.Application;
using Cqrs.Common.Application.Command;
using Cqrs.Common.Application.Query;
using Cqrs.Common.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Cqrs;

public static class ServiceCollectionExtensions
{
    public static void RegisterDevelopment(this IServiceCollection serviceCollection)
    {
        serviceCollection.RegisterDispatcher();
        serviceCollection.RegisterHandlers();
    }

    private static void RegisterHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<ICommandHandler<RandomIntegerGenerated>, GenerateRandomIntegersCommandHandler>()
            .AddTransient<IQueryHandler<RandomIntegerQueryResult>, RandomIntegerQueryHandler>();
    }

    private static void RegisterDispatcher(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<ICommandQueryDispatcher, CommandQueryDispatcher>()
            .AddSingleton<IEventBus, EventBus>()
            .AddSingleton<DevelopmentScopeProvider>();
    }
}
