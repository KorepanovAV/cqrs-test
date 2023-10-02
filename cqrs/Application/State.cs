using System;

namespace Cqrs.Application;

public class State
{
    public int Value { get; }

    public State()
    {
        var rand = new Random();
        this.Value = rand.Next(-100, 100);
    }
}
