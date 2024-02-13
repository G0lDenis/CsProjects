using System;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShipTests
{
    [Fact]
    public void ShipShouldHavePositiveFuelFails()
    {
        const int fuel = -1;

        Exception? exception = Record.Exception(() =>
        {
            var unused = new Meredian("Meredian 1", fuel, false);
        });

        Assert.NotNull(exception);
        Assert.IsType<ShipException>(exception);
        Assert.IsType<ArgumentException>(exception.InnerException);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    public void ShipShouldHavePositiveFuelSuccess(int fuel)
    {
        Exception? exception = Record.Exception(() =>
        {
            var unused = new PleasureShuttle("Pleasure Shuttle 1 ", fuel, false);
            var unused1 = new Augur("Augur 1", fuel, fuel, false);
        });

        Assert.Null(exception);
    }

    [Fact]
    public void TotalFuelPriceIsInCorrectInterval()
    {
        var ship = new PleasureShuttle("Pleasure Shuttle 1", 1, false);

        int fuelPrice = ship.GetPriceToFillWithFuel();

        Assert.True(fuelPrice is >= 50 and <= 150);
    }

    [Fact]
    public void TotalFuelPriceIsInCorrectInterval100Times()
    {
        for (int n = 0; n < 100; n++)
        {
            TotalFuelPriceIsInCorrectInterval();
        }
    }
}