using System;
using System.Threading;

namespace Cqrs.Common.Domain;

internal static class Development
{
    private static readonly AsyncLocal<string> _developmentId = new ();

    public static string DevelopmentId => _developmentId.Value;

    public static void AssignId(string developmentId)
    {
        _developmentId.Value = developmentId;
    }
}
