namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IPrototype<out T> : IComponent
    where T : IPrototype<T>
{
    T Clone();
}