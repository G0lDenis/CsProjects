using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public sealed class NeutrinoNebulaeEnvironment : Environment
{
    public NeutrinoNebulaeEnvironment(IReadOnlyCollection<Obstacle> obstacles)
        : base(obstacles)
    {
    }

    protected override TimeSpan? HaveNeededEngine(ISpaceShip ship, int miles)
    {
        var time = new TimeSpan(0);
        bool foundEngine = false;

        foreach (IEngine engine in ship.Engines
                     .Where(x => x is INeutrinoNebulaeEngine))
        {
            try
            {
                time = engine.GoForNMiles(miles);

                foundEngine = true;
                break;
            }
            catch (ShipException)
            {
            }
        }

        if (foundEngine)
            return time;

        return null;
    }

    internal class NeutrinoNebulaeEnvironmentBuilder
    {
        private readonly List<Obstacle> _obstacles;

        public NeutrinoNebulaeEnvironmentBuilder()
        {
            _obstacles = new List<Obstacle>();

#pragma warning disable CA5394
            int flockOfSpaceWhalesCount = Random.Shared.Next(0, 5);
#pragma warning restore CA5394

            for (int i = 0; i < flockOfSpaceWhalesCount; i++)
            {
                _obstacles.Add(new FlockOfSpaceWhalesObstacle());
            }
        }

        public NeutrinoNebulaeEnvironmentBuilder(int flockOfSpaceWhalesCount)
        {
            _obstacles = new List<Obstacle>();
            for (int i = 0; i < flockOfSpaceWhalesCount; i++)
            {
                _obstacles.Add(new FlockOfSpaceWhalesObstacle());
            }
        }

        public NeutrinoNebulaeEnvironment Build()
        {
            return new NeutrinoNebulaeEnvironment(_obstacles);
        }
    }
}