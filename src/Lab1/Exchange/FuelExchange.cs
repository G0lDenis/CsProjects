using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exchange;

public abstract class FuelExchange : IFuelExchange
{
    private readonly int _defaultPrice;

    protected FuelExchange(int defaultPrice)
    {
        _defaultPrice = defaultPrice;
    }

    public int GetFuelPrice()
    {
#pragma warning disable CA5394
        return _defaultPrice + (int)(Random.Shared.NextDouble() - 0.5);
#pragma warning restore CA5394
    }
}