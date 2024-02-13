using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public interface IEnvironment
{
    public ShipRunResult TravelThrough(ISpaceShip ship, int miles);
}