using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Common;

public abstract class ShipRunResult
{
    internal class Success : ShipRunResult
    {
        public Success(TimeSpan travelTime)
        {
            TravelTime = travelTime;
        }

        public Success()
        {
            TravelTime = new TimeSpan(0);
        }

        public TimeSpan TravelTime { get; }
    }

    internal class LostInSpace : ShipRunResult
    {
    }

    internal class DestructedByObstacle : ShipRunResult
    {
    }

    internal class CrewDied : ShipRunResult
    {
    }
}