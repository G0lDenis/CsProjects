using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.JumpingEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public sealed class Vaklas : SpaceShip
{
    public Vaklas(string name, int fuelForEClassImpulseEngine, int fuelForGammaJumpingEngine, bool hasPhotonDeflector)
        : base(
            name,
            new List<IEngine>
            {
                new EClassImpulseEngine(fuelForEClassImpulseEngine),
                new GammaJumpingEngine(fuelForGammaJumpingEngine),
            },
            new List<IDeflector>
            {
                new FirstClassDeflector(),
            },
            new SecondClassHull(),
            false,
            hasPhotonDeflector)
    {
    }
}