using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;

public sealed class SecondClassDeflector : HullDamageDeflector
{
    public SecondClassDeflector()
        : base(
            501,
            new ReadOnlyDictionary<DamagingObjects, float>(new Dictionary<DamagingObjects, float>
            {
                { DamagingObjects.Asteroid, 1.0f },
                { DamagingObjects.Meteorite, 1.7f },
                { DamagingObjects.FlockOfSpaceWhales, 4.0f },
            }))
    {
    }
}