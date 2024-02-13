using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Registry;

public class Registry : IRegistry
{
    public bool Register<T>(T element)
        where T : IPrototype<T>
    {
        return UniqueRegistry<T>.Register(element);
    }

    public bool TryGetElement<T>(string name, out T? value)
        where T : IPrototype<T>
    {
        return UniqueRegistry<T>.TryGetElement(name, out value);
    }

    private static class UniqueRegistry<T>
        where T : IPrototype<T>
    {
        private static readonly Dictionary<string, T> RegistryBase = new();

        public static bool Register(T element)
        {
            return RegistryBase.TryAdd(element.Name, element);
        }

        public static bool TryGetElement(string name, out T? value)
        {
            bool success = RegistryBase.TryGetValue(name, out T? result);
            value = result is not null ? result.Clone() : default;

            return success;
        }
    }
}