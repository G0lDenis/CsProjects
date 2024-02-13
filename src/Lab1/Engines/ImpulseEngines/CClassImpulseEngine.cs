using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.ImpulseEngines;

public sealed class CClassImpulseEngine : ImpulseEngine, INormalSpaceEngine
{
    public CClassImpulseEngine(int fuelAmount)
        : base(fuelAmount)
    {
    }

    protected override int FuelPerHour => 100;
    protected override int FuelForStart => 1_000;

    protected override TimeSpan CalculateTime(int miles)
    {
        return new TimeSpan((int)Math.Log(miles), 0, 0);
    }
}