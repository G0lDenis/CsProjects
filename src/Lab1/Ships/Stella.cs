using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.JumpingEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public sealed class Stella : SpaceShip
{
    public Stella(string name, int fuelForCClassImpulseEngine, int fuelForOmegaJumpingEngine, bool hasPhotonDeflector)
        : base(
            name,
            new List<IEngine>
            {
                new CClassImpulseEngine(fuelForCClassImpulseEngine),
                new OmegaJumpingEngine(fuelForOmegaJumpingEngine),
            },
            new List<IDeflector>
            {
                new FirstClassDeflector(),
            },
            new FirstClassHull(),
            false,
            hasPhotonDeflector)
    {
    }
}