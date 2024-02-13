using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;

public abstract class HullDamageDeflector : Damagable, IDeflector
{
    protected HullDamageDeflector(int healthPoints, IReadOnlyDictionary<DamagingObjects, float> multipliers)
        : base(healthPoints, multipliers)
    {
    }

    public bool TryToNeutralizeObstacle(Obstacle obstacle)
    {
        if (obstacle.Damage.CrewDamage) return false;

        return TryToTakeDamage(obstacle.Damage) is ShipRunResult.Success;
    }
}