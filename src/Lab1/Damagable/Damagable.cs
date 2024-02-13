using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damagable;

public abstract class Damagable
{
    protected Damagable(int healthPoints, IReadOnlyDictionary<DamagingObjects, float> multipliers)
    {
        HealthPoints = healthPoints;
        Multipliers = multipliers;
    }

    protected int HealthPoints { get; set; }

    protected IReadOnlyDictionary<DamagingObjects, float> Multipliers { get; }

    public ShipRunResult TryToTakeDamage(DamageInfo.DamageInfo damage)
    {
        if (damage.CrewDamage)
            return new ShipRunResult.CrewDied();

        float multiplier;
        if (!Multipliers.TryGetValue(damage.DamagingObject, out multiplier))
            multiplier = 1;

        int countedDamage = Convert.ToInt32(damage.HullDamage * multiplier);
        if (countedDamage > HealthPoints)
            return new ShipRunResult.DestructedByObstacle();

        HealthPoints -= countedDamage;
        return new ShipRunResult.Success();
    }
}