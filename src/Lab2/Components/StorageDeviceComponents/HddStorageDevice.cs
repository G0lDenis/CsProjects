namespace Itmo.ObjectOrientedProgramming.Lab2.Components.StorageDeviceComponents;

public sealed class HddStorageDevice : StorageDevice
{
    public HddStorageDevice(string name, int size, int power, int spindelSpeed)
        : base(name, size, power)
    {
        SpindelSpeed = spindelSpeed;
    }

    public int SpindelSpeed { get; }

    public override HddStorageDevice Clone()
    {
        return new HddStorageDevice(
            Name,
            Size,
            Power,
            SpindelSpeed);
    }
}