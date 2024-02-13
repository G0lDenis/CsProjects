using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public interface ISpaceShip
{
    public IEnumerable<IEngine> Engines { get; }

    public string Name { get; }

    public ShipRunResult TakeDamageFromObstacle(Obstacle obstacle);

    public int GetPriceToFillWithFuel();
}