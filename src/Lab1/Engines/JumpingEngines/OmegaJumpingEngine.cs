using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.JumpingEngines;

public sealed class OmegaJumpingEngine : JumpingEngine
{
    public OmegaJumpingEngine(int needFuelAmount)
        : base(needFuelAmount, 3_000)
    {
    }

    protected override bool TryToSpendFuel(TimeSpan time)
    {
        return FuelAmount.TryToSpendFuel(time.Hours * (int)Math.Log(time.Hours));
    }
}