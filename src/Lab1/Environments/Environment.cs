using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public abstract class Environment : IEnvironment
{
    protected Environment(IReadOnlyCollection<Obstacle> obstacles)
    {
        Obstacles = obstacles;
    }

    private IReadOnlyCollection<Obstacle> Obstacles { get; }

    public ShipRunResult TravelThrough(ISpaceShip ship, int miles)
    {
        TimeSpan? time = HaveNeededEngine(ship, miles);
        if (time is null)
            return new ShipRunResult.LostInSpace();

        foreach (Obstacle obstacle in Obstacles)
        {
            ShipRunResult result = ship.TakeDamageFromObstacle(obstacle);
            if (result is not ShipRunResult.Success)
                return result;
        }

        return new ShipRunResult.Success(time.Value);
    }

    protected abstract TimeSpan? HaveNeededEngine(ISpaceShip ship, int miles);
}