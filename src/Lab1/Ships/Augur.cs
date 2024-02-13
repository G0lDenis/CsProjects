using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.JumpingEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public sealed class Augur : SpaceShip
{
    public Augur(string name, int fuelForEClassImpulseEngine, int fuelForAlphaJumpingEngine, bool hasPhotonDeflector)
        : base(
            name,
            new List<IEngine>
            {
                new EClassImpulseEngine(fuelForEClassImpulseEngine),
                new AlphaJumpingEngine(fuelForAlphaJumpingEngine),
            },
            new List<IDeflector>
            {
                new ThirdClassDeflector(),
            },
            new ThirdClassHull(),
            false,
            hasPhotonDeflector)
    {
    }
}