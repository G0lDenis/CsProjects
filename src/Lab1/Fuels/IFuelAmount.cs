namespace Itmo.ObjectOrientedProgramming.Lab1.Fuels;

public interface IFuelAmount
{
    public int Amount { get; }

    public int Price { get; }

    public bool TryToSpendFuel(int fuel);
}