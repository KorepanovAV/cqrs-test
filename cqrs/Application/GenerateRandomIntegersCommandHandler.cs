using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cqrs.Common.Application.Command;

namespace Cqrs.Application;

public class GenerateRandomIntegersCommandHandler
    : CommandHandler<GenerateRandomIntegersCommand, RandomIntegerGenerated>
{
    protected override async IAsyncEnumerable<RandomIntegerGenerated> HandleAsync(GenerateRandomIntegersCommand command)
    {
        var rand = new Random();
        foreach (var _ in Enumerable.Range(0, command.Count))
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            yield return new RandomIntegerGenerated(rand.Next(0, 100));
        }
    }

    protected override IEnumerable<RandomIntegerGenerated> Handle(GenerateRandomIntegersCommand command)
    {
        var rand = new Random();
        foreach (var item in Enumerable.Range(0, command.Count))
        {
            yield return new RandomIntegerGenerated(rand.Next(0, 100));
        }
    }
}
