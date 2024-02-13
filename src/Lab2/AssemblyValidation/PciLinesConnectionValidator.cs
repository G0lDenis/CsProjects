using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.StorageDeviceComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapterComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public class PciLinesConnectionValidator : IComponentPlacementValidator
{
    private readonly IMotherBoard _motherBoard;
    private readonly IVideoCard? _videoCard;
    private readonly IWifiAdapter? _wifiAdapter;
    private readonly IEnumerable<IStorageDevice> _storageDevices;

    public PciLinesConnectionValidator(
        IMotherBoard motherBoard,
        IVideoCard? videoCard,
        IWifiAdapter? wifiAdapter,
        IEnumerable<IStorageDevice> storageDevices)
    {
        _motherBoard = motherBoard;
        _videoCard = videoCard;
        _wifiAdapter = wifiAdapter;
        _storageDevices = storageDevices;
    }

    public bool Validate(ref BuildResult result)
    {
        IDictionary<PciLine, int> assemblyLines = new Dictionary<PciLine, int>();

        if (_videoCard is not null)
        {
            if (!assemblyLines.ContainsKey(_videoCard.PciLine))
                assemblyLines.Add(_videoCard.PciLine, 0);
            assemblyLines[_videoCard.PciLine]++;
        }

        if (_wifiAdapter is not null)
        {
            if (!assemblyLines.ContainsKey(_wifiAdapter.PciLine))
                assemblyLines.Add(_wifiAdapter.PciLine, 0);
            assemblyLines[_wifiAdapter.PciLine]++;
        }

        foreach (IStorageDevice storageDevice in _storageDevices)
        {
            if (storageDevice is SsdStorageDevice { SupportedPciLine: not null } device)
            {
                if (!assemblyLines.ContainsKey(device.SupportedPciLine))
                    assemblyLines.Add(device.SupportedPciLine, 0);
                assemblyLines[device.SupportedPciLine]++;
            }
        }

        foreach (PciLine pciLine in assemblyLines.Keys)
        {
            if (!_motherBoard.PciLines.ContainsKey(pciLine)
                || _motherBoard.PciLines[pciLine] < assemblyLines[pciLine])
            {
                result = new BuildResult.BuildFail(
                    "One of PCI lines cannot be connected to mother board");
                return false;
            }
        }

        return true;
    }
}