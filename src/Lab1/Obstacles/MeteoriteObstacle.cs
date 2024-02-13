using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public sealed class MeteoriteObstacle : Obstacle
{
    public MeteoriteObstacle()
        : base(new DamageInfo.DamageInfo(100, false, DamagingObjects.Meteorite))
    {
    }
}