using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damagable.Hulls;

public abstract class Hull : Damagable
{
    protected Hull(int healthPoints, IReadOnlyDictionary<DamagingObjects, float> multipliers)
        : base(healthPoints, multipliers)
    {
    }
}