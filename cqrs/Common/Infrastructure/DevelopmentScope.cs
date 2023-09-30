using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cqrs.Common.Infrastructure;

internal sealed class DevelopmentScope : IDisposable
{
    private readonly IServiceScope _scope;

    public string Id { get; }

    public DevelopmentScope(string id, IServiceScope scope)
    {
        Id = id;
        _scope = scope;
    }

    public T GetService<T>()
    {
        return _scope.ServiceProvider.GetService<T>();
    }

    public void Dispose()
    {
        _scope.Dispose();
    }
}
