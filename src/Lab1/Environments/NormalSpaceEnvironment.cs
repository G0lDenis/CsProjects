using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public sealed class NormalSpaceEnvironment : Environment
{
    public NormalSpaceEnvironment(IReadOnlyCollection<Obstacle> obstacles)
        : base(obstacles)
    {
    }

    protected override TimeSpan? HaveNeededEngine(ISpaceShip ship, int miles)
    {
        var time = new TimeSpan(0);
        bool foundEngine = false;

        foreach (IEngine engine in ship.Engines
                     .Where(x => x is INormalSpaceEngine))
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

    internal class NormalSpaceEnvironmentBuilder
    {
        private readonly List<Obstacle> _obstacles;

        public NormalSpaceEnvironmentBuilder()
        {
            _obstacles = new List<Obstacle>();

#pragma warning disable CA5394
            int meteoriteCount = Random.Shared.Next(0, 5);
            int asteroidCount = Random.Shared.Next(0, 5);
#pragma warning restore CA5394

            for (int i = 0; i < meteoriteCount; i++)
            {
                _obstacles.Add(new MeteoriteObstacle());
            }

            for (int i = 0; i < asteroidCount; i++)
            {
                _obstacles.Add(new AsteroidObstacle());
            }
        }

        public NormalSpaceEnvironmentBuilder(int meteoriteCount, int asteroidCount)
        {
            _obstacles = new List<Obstacle>();
            for (int i = 0; i < meteoriteCount; i++)
            {
                _obstacles.Add(new MeteoriteObstacle());
            }

            for (int i = 0; i < asteroidCount; i++)
            {
                _obstacles.Add(new AsteroidObstacle());
            }
        }

        public NormalSpaceEnvironment Build()
        {
            return new NormalSpaceEnvironment(_obstacles);
        }
    }
}