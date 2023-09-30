using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Cqrs.Common.Infrastructure;

internal interface IDevelopmentScope : IDisposable
{
    string Id { get; }

    T GetService<T>();
}

internal sealed class DevelopmentScopeProvider
{
    private sealed class DevelopmentScope : IDevelopmentScope
    {
        private readonly IServiceScope _scope;

        private readonly Action<DevelopmentScope> _onScopeDisposing;

        public string Id { get; }

        public DevelopmentScope(string id, IServiceProvider serviceProvider,
            Action<DevelopmentScope> onScopeCreating, Action<DevelopmentScope> onScopeDisposing)
        {
            Id = id;
            _scope = serviceProvider.CreateScope();
            _onScopeDisposing = onScopeDisposing;
            onScopeCreating.Invoke(this);
        }

        public T GetService<T>()
        {
            return _scope.ServiceProvider.GetService<T>();
        }

        public void Dispose()
        {
            _onScopeDisposing.Invoke(this);
            _scope.Dispose();

        }

        public override bool Equals(object? obj)
        {
            if (obj is DevelopmentScope scope)
            {
                return this.Equals(obj);
            }

            return false;
        }

        private bool Equals(DevelopmentScope other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    private ImmutableList<DevelopmentScope> _scopes = ImmutableList<DevelopmentScope>.Empty;

    private readonly IServiceProvider _serviceProvider;

    public IDevelopmentScope Get(string developmentId)
    {
        var scope = _scopes.SingleOrDefault(scope => scope.Id == developmentId);
        return scope ?? new DevelopmentScope(developmentId, _serviceProvider, AddScope, RemoveScope);
    }

    public IDevelopmentScope Get()
    {
        return new DevelopmentScope("anonymous", _serviceProvider, AddScope, RemoveScope);
    }

    private void AddScope(DevelopmentScope scope)
    {
        _scopes = _scopes.Add(scope);
    }

    private void RemoveScope(DevelopmentScope scope)
    {
        _scopes = _scopes.Remove(scope);
    }

    public DevelopmentScopeProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}
