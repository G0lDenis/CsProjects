using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.ImpulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public sealed class Meredian : SpaceShip
{
    public Meredian(string name, int fuelEClassImpulseEngine, bool hasPhotonDeflector)
        : base(
            name,
            new List<IEngine>
            {
                new EClassImpulseEngine(fuelEClassImpulseEngine),
            },
            new List<IDeflector>
            {
                new SecondClassDeflector(),
            },
            new SecondClassHull(),
            true,
            hasPhotonDeflector)
    {
    }
}