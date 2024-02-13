using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.JumpingEngines;

public sealed class GammaJumpingEngine : JumpingEngine
{
    public GammaJumpingEngine(int needFuelAmount)
        : base(needFuelAmount, 2_000)
    {
    }

    protected override bool TryToSpendFuel(TimeSpan time)
    {
        return FuelAmount.TryToSpendFuel((int)Math.Pow(time.Hours, 3));
    }
}