using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public interface IRouteSegment
{
    public ShipRunResult TravelThrough(ISpaceShip ship);
}