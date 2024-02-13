namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnitComponents;

public class PowerUnit : IPowerUnit
{
    public PowerUnit(string name, int maxVoltage)
    {
        Name = name;
        MaxPower = maxVoltage;
    }

    public string Name { get; }

    public int MaxPower { get; }

    public PowerUnit Clone()
    {
        return new PowerUnit(Name, MaxPower);
    }
}