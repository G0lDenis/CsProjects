using Itmo.ObjectOrientedProgramming.Lab1.DamageInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class AntiMatterFlashObstacle : Obstacle
{
    public AntiMatterFlashObstacle()
        : base(new DamageInfo.DamageInfo(0, true, DamagingObjects.AntiMatterFlash))
    {
    }
}