using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapterComponents;

public interface IWifiAdapter : IPrototype<WifiAdapter>
{
    public string WiFiStandard { get; }

    public bool HasBluetoothModule { get; }

    public PciLine PciLine { get; }

    public int Power { get; }
}