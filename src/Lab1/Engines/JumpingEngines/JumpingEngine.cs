using System;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Exchange;
using Itmo.ObjectOrientedProgramming.Lab1.Fuels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.JumpingEngines;

public abstract class JumpingEngine : IHighDensityNebulaeEngine
{
    private readonly int _segmentMaxLength;

    protected JumpingEngine(int needFuelAmount, int segmentMaxLength)
    {
        _segmentMaxLength = segmentMaxLength;
        FuelAmount = new FuelAmount(new PlasmaFuelExchange(), needFuelAmount);
    }

    protected IFuelAmount FuelAmount { get; set; }

    public TimeSpan GoForNMiles(int miles)
    {
        var time = new TimeSpan(miles, 0, 0);

        if (miles > _segmentMaxLength)
            throw new MaxLengthIsLessThanNeedException();
        if (!TryToSpendFuel(time))
            throw new NotEnoughFuelException();

        return time;
    }

    public int GetPriceOfFuel()
    {
        return FuelAmount.Price;
    }

    protected abstract bool TryToSpendFuel(TimeSpan time);
}