using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class Route
{
    public Route(IReadOnlyCollection<IRouteSegment> segments)
    {
        Segments = segments;
    }

    private IReadOnlyCollection<IRouteSegment> Segments { get; }

    public ShipRunResult TravelThrough(ISpaceShip ship)
    {
        var summaryTime = new TimeSpan(0);
        foreach (IRouteSegment segment in Segments)
        {
            ShipRunResult result = segment.TravelThrough(ship);
            if (result is not ShipRunResult.Success success)
                return result;
            summaryTime += success.TravelTime;
        }

        return new ShipRunResult.Success(summaryTime);
    }
}