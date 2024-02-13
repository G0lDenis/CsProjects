using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public sealed class FlockOfSpaceWhalesObstacle : Obstacle
{
    public FlockOfSpaceWhalesObstacle()
        : base(new DamageInfo.DamageInfo(150, false, DamagingObjects.FlockOfSpaceWhales))
    {
    }
}