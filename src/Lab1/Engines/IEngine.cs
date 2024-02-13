using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public interface IEngine
{
    public TimeSpan GoForNMiles(int miles);

    public int GetPriceOfFuel();
}