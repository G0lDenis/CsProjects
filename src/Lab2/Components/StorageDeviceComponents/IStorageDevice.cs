namespace Itmo.ObjectOrientedProgramming.Lab2.Components.StorageDeviceComponents;

public interface IStorageDevice : IPrototype<StorageDevice>
{
    public int Size { get; }
    public int Power { get; }
}