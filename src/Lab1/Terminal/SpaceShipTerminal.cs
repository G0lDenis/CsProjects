using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Terminal;

public class SpaceShipTerminal
{
    private ICollection<ISpaceShip> _ships = new Collection<ISpaceShip>(new List<ISpaceShip>());

    public void AddShip(ISpaceShip ship)
    {
        _ships.Add(ship);
    }

    public string? TryToTravelThrough(Route.Route route)
    {
        var fuelShips = new Dictionary<string, int>();

        foreach (ISpaceShip ship in _ships)
        {
            if (route.TravelThrough(ship) is ShipRunResult.Success)
                fuelShips.Add(ship.Name, ship.GetPriceToFillWithFuel());
        }

        if (fuelShips.Count == 0)
            return null;

        return fuelShips.MinBy(ship => ship.Value).Key;
    }
}