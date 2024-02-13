using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;

public class PhotonDeflector : IDeflector
{
    private int _canBlockEmission = 3;

    public bool TryToNeutralizeObstacle(Obstacle obstacle)
    {
        if (obstacle.Damage.HullDamage == 0 && _canBlockEmission > 0)
        {
            _canBlockEmission--;

            return true;
        }

        return false;
    }
}