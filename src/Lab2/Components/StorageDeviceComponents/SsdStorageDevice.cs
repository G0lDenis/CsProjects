using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.StorageDeviceComponents;

public sealed class SsdStorageDevice : StorageDevice
{
    public SsdStorageDevice(string name, int size, int power, int speed, PciLine? supportedPciLine)
        : base(name, size, power)
    {
        Speed = speed;
        SupportedPciLine = supportedPciLine;
    }

    public int Speed { get; }

    public PciLine? SupportedPciLine { get; }

    public override SsdStorageDevice Clone()
    {
        return new SsdStorageDevice(
            Name,
            Size,
            Power,
            Speed,
            SupportedPciLine);
    }
}