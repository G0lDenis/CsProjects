namespace Itmo.ObjectOrientedProgramming.Lab2.Components.StorageDeviceComponents;

public abstract class StorageDevice : IStorageDevice
{
    protected StorageDevice(string name, int size, int power)
    {
        Name = name;
        Size = size;
        Power = power;
    }

    public string Name { get; }

    public int Size { get; }

    public int Power { get; }

    public abstract StorageDevice Clone();
}