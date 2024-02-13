namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public abstract class Obstacle
{
    protected Obstacle(DamageInfo.DamageInfo damage)
    {
        Damage = damage;
    }

    public DamageInfo.DamageInfo Damage { get; }
}