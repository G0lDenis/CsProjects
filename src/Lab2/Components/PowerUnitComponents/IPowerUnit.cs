namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnitComponents;

public interface IPowerUnit : IPrototype<PowerUnit>
{
    public int MaxPower { get; }
}