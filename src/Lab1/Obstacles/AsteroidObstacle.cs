using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class AsteroidObstacle : Obstacle
{
    public AsteroidObstacle()
        : base(new DamageInfo.DamageInfo(50, false, DamagingObjects.Asteroid))
    {
    }
}