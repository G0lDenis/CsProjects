using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.JumpingEngines;

public sealed class AlphaJumpingEngine : JumpingEngine
{
    public AlphaJumpingEngine(int needFuelAmount)
        : base(needFuelAmount, 1_000)
    {
    }

    protected override bool TryToSpendFuel(TimeSpan time)
    {
        return FuelAmount.TryToSpendFuel(time.Hours);
    }
}