using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Registry;

public interface IRegistry
{
    public bool Register<T>(T element)
        where T : IPrototype<T>;

    public bool TryGetElement<T>(string name, out T? value)
        where T : IPrototype<T>;
}