using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapterComponents;

public class WifiAdapter : IWifiAdapter
{
    private WifiAdapter(
        string name,
        string wiFiStandard,
        bool hasBluetoothModule,
        PciLine pciLine,
        int power)
    {
        Name = name;
        WiFiStandard = wiFiStandard;
        HasBluetoothModule = hasBluetoothModule;
        PciLine = pciLine;
        Power = power;
    }

    public string Name { get; }

    public string WiFiStandard { get; }

    public bool HasBluetoothModule { get; }

    public PciLine PciLine { get; }

    public int Power { get; }

    public WifiAdapter Clone()
    {
        return new WifiAdapter(
            Name,
            WiFiStandard,
            HasBluetoothModule,
            PciLine,
            Power);
    }

    public class WifiModuleBuilder
    {
        private string? _name;
        private string? _wifiStandard;
        private bool? _hasBluetoothModule;
        private PciLine? _pciLine;
        private int? _power;

        public WifiModuleBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public WifiModuleBuilder WithWifiStandard(string wifiStandard)
        {
            _wifiStandard = wifiStandard;
            return this;
        }

        public WifiModuleBuilder WithHasBluetoothModule(bool hasBluetoothModule)
        {
            _hasBluetoothModule = hasBluetoothModule;
            return this;
        }

        public WifiModuleBuilder WithPciLine(PciLine pciLine)
        {
            _pciLine = pciLine;
            return this;
        }

        public WifiModuleBuilder WithPower(int power)
        {
            _power = power;
            return this;
        }

        public WifiAdapter Build()
        {
            return new WifiAdapter(
                _name ?? throw new ComponentBuilderException("WiFi adapter name cannot be empty"),
                _wifiStandard ?? throw new ComponentBuilderException("WiFi adapter WiFi standard cannot be empty"),
                _hasBluetoothModule ?? false,
                _pciLine ?? throw new ComponentBuilderException("WiFi adapter PCI line cannot be empty"),
                _power ?? throw new ComponentBuilderException("WiFi adapter power cannot be empty"));
        }
    }
}