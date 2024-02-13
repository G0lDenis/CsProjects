using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.ImpulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public sealed class PleasureShuttle : SpaceShip
{
    public PleasureShuttle(string name, int fuelForCClassImpulseEngine, bool hasPhotonDeflector)
        : base(
            name,
            new List<IEngine>
            {
                new CClassImpulseEngine(fuelForCClassImpulseEngine),
            },
            new List<IDeflector>(),
            new FirstClassHull(),
            false,
            hasPhotonDeflector)
    {
    }
}