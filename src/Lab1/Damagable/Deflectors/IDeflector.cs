using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;

public interface IDeflector
{
    public bool TryToNeutralizeObstacle(Obstacle obstacle);
}