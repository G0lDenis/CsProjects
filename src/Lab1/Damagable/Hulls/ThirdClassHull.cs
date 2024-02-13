using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damagable.Hulls;

public sealed class ThirdClassHull : Hull
{
    public ThirdClassHull()
        : base(
            1_001,
            new ReadOnlyDictionary<DamagingObjects, float>(new Dictionary<DamagingObjects, float>
            {
                { DamagingObjects.Asteroid, 1.0f },
                { DamagingObjects.Meteorite, 2.0f },
                { DamagingObjects.FlockOfSpaceWhales, 8.0f },
            }))
    {
    }
}