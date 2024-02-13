using System;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Exchange;
using Itmo.ObjectOrientedProgramming.Lab1.Fuels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.ImpulseEngines;

public abstract class ImpulseEngine : IEngine
{
    private readonly IFuelAmount _fuelAmount;

    protected ImpulseEngine(int needFuelAmount)
    {
        _fuelAmount = new FuelAmount(new CommonFuelExchange(), needFuelAmount);
    }

    protected abstract int FuelPerHour { get; }

    protected abstract int FuelForStart { get; }

    public TimeSpan GoForNMiles(int miles)
    {
        TimeSpan time = CalculateTime(miles);

        if (!TryToSpendFuel(time))
            throw new NotEnoughFuelException();

        return time;
    }

    public int GetPriceOfFuel()
    {
        return _fuelAmount.Price;
    }

    protected abstract TimeSpan CalculateTime(int miles);

    private bool TryToSpendFuel(TimeSpan time)
    {
        return _fuelAmount.TryToSpendFuel(FuelForStart + (time.Hours * FuelPerHour));
    }
}