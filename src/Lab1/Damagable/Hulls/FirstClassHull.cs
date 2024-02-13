using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damagable.Hulls;

public sealed class FirstClassHull : Hull
{
    public FirstClassHull()
        : base(
            51,
            new ReadOnlyDictionary<DamagingObjects, float>(new Dictionary<DamagingObjects, float>
            {
                { DamagingObjects.Asteroid, 1.0f },
                { DamagingObjects.Meteorite, 1.0f },
                { DamagingObjects.FlockOfSpaceWhales, 1.0f },
            }))
    {
    }
}