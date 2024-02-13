using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Damagable.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public abstract class SpaceShip : ISpaceShip
{
    private readonly IReadOnlyCollection<IEngine> _engines;
    private readonly IReadOnlyCollection<IDeflector> _deflectors;
    private readonly Hull _hull;
    private readonly bool _hasAntinitrineEmitter;

    protected SpaceShip(
        string name,
        IReadOnlyCollection<IEngine> engines,
        IReadOnlyCollection<IDeflector> deflectors,
        Hull hull,
        bool hasAntinitrineEmitter,
        bool hasPhotonDeflector)
    {
        _engines = engines;
        _hull = hull;
        _hasAntinitrineEmitter = hasAntinitrineEmitter;

        Name = name;

        var newDeflectors = new List<IDeflector>(deflectors);
        if (hasPhotonDeflector)
            newDeflectors.Add(new PhotonDeflector());
        _deflectors = new ReadOnlyCollection<IDeflector>(newDeflectors);
    }

    public string Name { get; }

    public IEnumerable<IEngine> Engines
    {
        get
        {
            foreach (IEngine engine in _engines)
            {
                yield return engine;
            }
        }
    }

    public ShipRunResult TakeDamageFromObstacle(Obstacle obstacle)
    {
        if (obstacle is FlockOfSpaceWhalesObstacle && _hasAntinitrineEmitter)
            return new ShipRunResult.Success();

        bool neutralized = false;
        foreach (IDeflector deflector in _deflectors)
        {
            if (deflector.TryToNeutralizeObstacle(obstacle))
            {
                neutralized = true;
                break;
            }
        }

        if (neutralized)
            return new ShipRunResult.Success();

        return _hull.TryToTakeDamage(obstacle.Damage);
    }

    public int GetPriceToFillWithFuel()
        => Engines.Sum(engine => engine.GetPriceOfFuel());
}