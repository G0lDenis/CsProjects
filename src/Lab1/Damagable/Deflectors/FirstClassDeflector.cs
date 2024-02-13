using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;

public sealed class FirstClassDeflector : HullDamageDeflector
{
    public FirstClassDeflector()
        : base(
            101,
            new ReadOnlyDictionary<DamagingObjects, float>(new Dictionary<DamagingObjects, float>
            {
                { DamagingObjects.Asteroid, 1.0f },
                { DamagingObjects.Meteorite, 1.0f },
                { DamagingObjects.FlockOfSpaceWhales, 1.0f },
            }))
    {
    }
}