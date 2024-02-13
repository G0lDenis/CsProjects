using System;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Exchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Fuels;

public class FuelAmount : IFuelAmount
{
    private readonly IFuelExchange _exchange;

    public FuelAmount(IFuelExchange exchange, int amount)
    {
        _exchange = exchange;

        if (amount < 0)
        {
            throw new ShipException(
                "Validation exception",
                new ArgumentException("Fuel amount must be positive number", nameof(amount)));
        }

        Amount = amount;
    }

    public int Amount { get; private set; }

    public int Price => _exchange.GetFuelPrice() * Amount;

    public bool TryToSpendFuel(int fuel)
    {
        if (fuel > Amount) return false;

        Amount -= fuel;

        return true;
    }
}