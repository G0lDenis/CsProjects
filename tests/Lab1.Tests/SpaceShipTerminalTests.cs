using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Terminal;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceShipTerminalTests
{
    [Fact]
    public void ShipMustBeLessPriceToFuelForRouteTest()
    {
        var terminal = new SpaceShipTerminal();
        var spceBuilder = new NormalSpaceEnvironment.NormalSpaceEnvironmentBuilder(0, 0);
        NormalSpaceEnvironment environment = spceBuilder.Build();
        IRouteSegment segment = new RouteSegment(environment, 10);
        var route = new Route.Route(new List<IRouteSegment>
        {
            segment,
        });
        var pleasureShuttle = new PleasureShuttle("Better", 3_000, false);
        var vaklas = new Vaklas("Worse", 3_000, 1_000, false);
        terminal.AddShip(pleasureShuttle);
        terminal.AddShip(vaklas);

        string? result = terminal.TryToTravelThrough(route);

        Assert.NotNull(result);
        Assert.Equal("Better", result);
    }

    [Fact]
    public void VaklasMustBeChosenForNeutrinoNebulaeInsteadPleasureShuttleTest()
    {
        var terminal = new SpaceShipTerminal();
        var nebulaeBuilder = new NeutrinoNebulaeEnvironment.NeutrinoNebulaeEnvironmentBuilder(0);
        NeutrinoNebulaeEnvironment environment = nebulaeBuilder.Build();
        IRouteSegment segment = new RouteSegment(environment, 10);
        var route = new Route.Route(new List<IRouteSegment>
        {
            segment,
        });
        var pleasureShuttle = new PleasureShuttle("NoChance", 3_000, false);
        var vaklas = new Vaklas("Nice", 3_000, 1_000, false);
        terminal.AddShip(pleasureShuttle);
        terminal.AddShip(vaklas);

        string? result = terminal.TryToTravelThrough(route);

        Assert.NotNull(result);
        Assert.Equal("Nice", result);
    }

    [Fact]
    public void MustChooseShipThatCanGetThroughLongRouteTest()
    {
        var terminal = new SpaceShipTerminal();
        var nebulaeBuilder = new HighDensityNebulaeEnvironment.HighDensityNebulaeEnvironmentBuilder(0);
        HighDensityNebulaeEnvironment environment = nebulaeBuilder.Build();
        IRouteSegment segment = new RouteSegment(environment, 2_000);
        var route = new Route.Route(new List<IRouteSegment>
        {
            segment,
        });
        var augur = new Augur("Augur", 3_000, 3_000, false);
        var stella = new Stella("Stella", 3_000, 1_000, false);
        terminal.AddShip(augur);
        terminal.AddShip(stella);

        string? result = terminal.TryToTravelThrough(route);

        Assert.NotNull(result);
        Assert.Equal("Stella", result);
    }

    [Fact]
    public void LongRouteTest()
    {
        var terminal = new SpaceShipTerminal();

        var nebulaeBuilder = new HighDensityNebulaeEnvironment.HighDensityNebulaeEnvironmentBuilder(1);
        HighDensityNebulaeEnvironment environment = nebulaeBuilder.Build();
        IRouteSegment segment = new RouteSegment(environment, 1_000);

        var normalSpaceBuilder = new NormalSpaceEnvironment.NormalSpaceEnvironmentBuilder(1, 5);
        NormalSpaceEnvironment environment1 = normalSpaceBuilder.Build();
        IRouteSegment segment2 = new RouteSegment(environment1, 1_000);

        var route = new Route.Route(new List<IRouteSegment>
        {
            segment,
            segment2,
        });

        var augur = new Augur("Augur", 3_000, 3_000, true);
        terminal.AddShip(augur);

        string? result = terminal.TryToTravelThrough(route);

        Assert.NotNull(result);
        Assert.Equal("Augur", result);
    }
}