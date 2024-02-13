using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;

public sealed class ThirdClassDeflector : HullDamageDeflector
{
    public ThirdClassDeflector()
        : base(
            2_001,
            new ReadOnlyDictionary<DamagingObjects, float>(new Dictionary<DamagingObjects, float>
            {
                { DamagingObjects.Asteroid, 1.0f },
                { DamagingObjects.Meteorite, 2.0f },
                { DamagingObjects.FlockOfSpaceWhales, 10.0f },
            }))
    {
    }
}