using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class RouteSegment : IRouteSegment
{
    private readonly IEnvironment _environment;

    private readonly int _distanceInMiles;

    public RouteSegment(Environment environment, int distanceInMiles)
    {
        _environment = environment;
        _distanceInMiles = distanceInMiles;
    }

    public ShipRunResult TravelThrough(ISpaceShip ship)
    {
        return _environment.TravelThrough(ship, _distanceInMiles);
    }
}