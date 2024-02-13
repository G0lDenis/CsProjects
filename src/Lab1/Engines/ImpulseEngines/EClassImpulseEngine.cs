using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.ImpulseEngines;

public sealed class EClassImpulseEngine : ImpulseEngine, INormalSpaceEngine, INeutrinoNebulaeEngine
{
    public EClassImpulseEngine(int fuelAmount)
        : base(fuelAmount)
    {
    }

    protected override int FuelPerHour => 200;
    protected override int FuelForStart => 2_000;

    protected override TimeSpan CalculateTime(int miles)
    {
        return new TimeSpan(miles / 10, 0, 0);
    }
}