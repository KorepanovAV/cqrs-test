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
        serviceCollection
            .RegisterDispatcher()
            .RegisterHandlers()
            .RegisterDevelopmentState();
    }

    private static IServiceCollection RegisterHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<ICommandHandler<RandomIntegerGenerated>, GenerateRandomIntegersCommandHandler>()
            .AddTransient<IQueryHandler<RandomIntegerQueryResult>, RandomIntegerQueryHandler>()
            .AddTransient<IQueryHandler<MemoizedRandomIntergerQueryResult>, MemoizedRandomIntegerQueryHandler>();

        return serviceCollection;
    }

    private static IServiceCollection RegisterDispatcher(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<ICommandQueryDispatcher, CommandQueryDispatcher>()
            .AddSingleton<IEventBus, EventBus>()
            .AddSingleton<DevelopmentScopeProvider>();

        return serviceCollection;
    }

    private static IServiceCollection RegisterDevelopmentState(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<State>();

        return serviceCollection;
    }
}
