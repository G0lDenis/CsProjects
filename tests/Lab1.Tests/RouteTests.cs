using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteTests
{
    public static IEnumerable<object[]> RouteWithHighDensityNebulaeGenerator(int miles)
    {
        var nebulaeBuilder = new HighDensityNebulaeEnvironment.HighDensityNebulaeEnvironmentBuilder(0);
        HighDensityNebulaeEnvironment environment = nebulaeBuilder.Build();
        IRouteSegment segment = new RouteSegment(environment, miles);
        var route = new Route.Route(new List<IRouteSegment>
        {
            segment,
        });

        return new List<object[]> { new object[] { route } };
    }

    public static IEnumerable<object[]> VaklasShipGenerator(bool hasPhotonDeflector)
    {
        return new List<object[]>
        {
            new object[]
            {
                new Vaklas(
                    "Vasya",
                    100,
                    100,
                    hasPhotonDeflector),
            },
        };
    }

    public static IEnumerable<object[]> DataForAntiMatterFlashObstacleTests(bool hasPhotonDeflector)
    {
        var nebulaeBuilder = new HighDensityNebulaeEnvironment.HighDensityNebulaeEnvironmentBuilder(1);
        HighDensityNebulaeEnvironment environment = nebulaeBuilder.Build();
        IRouteSegment segment = new RouteSegment(environment, 1);
        var route = new Route.Route(new List<IRouteSegment>
        {
            segment,
        });
        var ship = (ISpaceShip)VaklasShipGenerator(hasPhotonDeflector).First().First();

        if (ship is null)
            throw new ShipException();

        return new List<object[]>
        {
            new object[] { ship, route },
        };
    }

    public static IEnumerable<object[]> DataForAntinitrineNebulaeEnvironmentWithFlockOfSpaceWhalesTest()
    {
        var nebulaeBuilder = new NeutrinoNebulaeEnvironment.NeutrinoNebulaeEnvironmentBuilder(1);
        NeutrinoNebulaeEnvironment environment = nebulaeBuilder.Build();
        IRouteSegment segment = new RouteSegment(environment, 10);
        var route = new Route.Route(new List<IRouteSegment>
        {
            segment,
        });

        return new List<object[]>
        {
            new object[]
            {
                new Vaklas("VaklasShip", 1_000_000, 1_000_000, false),
                route,
                new ShipRunResult.DestructedByObstacle(),
            },
            new object[]
            {
                new Augur("AugurShip", 1_000_000, 1_000_000, false),
                route,
                new ShipRunResult.Success(),
            },
            new object[]
            {
                new Meredian("MeredianShip", 1_000_000, false),
                route,
                new ShipRunResult.Success(),
            },
        };
    }

    [Theory]
    [MemberData(nameof(RouteWithHighDensityNebulaeGenerator), parameters: 1)]
    public void ShipMustHaveJumpingEngineToGetThroughHighDensityNebulaeEnvironmentTest(Route.Route route)
    {
        var ship = new PleasureShuttle("TestShuttle", 1_000_000, false);

        ShipRunResult result = route.TravelThrough(ship);

        Assert.IsType<ShipRunResult.LostInSpace>(result);
    }

    [Theory]
    [MemberData(nameof(RouteWithHighDensityNebulaeGenerator), parameters: 50_000)]
    public void JumpingEngineMustHaveEnoughDistanceToGetThroughHighDensityNebulaeEnvironmentTest(Route.Route route)
    {
        var ship = new Augur("TestShuttle", 1_000_000, 1_000_000, false);

        ShipRunResult result = route.TravelThrough(ship);

        Assert.IsType<ShipRunResult.LostInSpace>(result);
    }

    [Theory]
    [MemberData(nameof(DataForAntiMatterFlashObstacleTests), parameters: false)]
    public void ShipCrewMustDieIfDoesntHavePhotonDeflectorToBlockAntiMatterFlashObstacleTest(
        ISpaceShip ship,
        Route.Route route)
    {
        Assert.IsType<ShipRunResult.CrewDied>(route.TravelThrough(ship));
    }

    [Theory]
    [MemberData(nameof(DataForAntiMatterFlashObstacleTests), parameters: true)]
    public void ShipCrewMustBeAliveIfHavePhotonDeflectorToBlockAntiMatterFlashObstacleTest(
        ISpaceShip ship,
        Route.Route route)
    {
        Assert.IsType<ShipRunResult.Success>(route.TravelThrough(ship));
    }

    [Theory]
    [MemberData(nameof(DataForAntinitrineNebulaeEnvironmentWithFlockOfSpaceWhalesTest))]
    public void AntinitrineNebulaeEnvironmentWithFlockOfSpaceWhalesTest(
        ISpaceShip ship,
        Route.Route route,
        ShipRunResult shipRunResult)
    {
        Assert.Equal(shipRunResult.GetType(), route.TravelThrough(ship).GetType());
    }
}