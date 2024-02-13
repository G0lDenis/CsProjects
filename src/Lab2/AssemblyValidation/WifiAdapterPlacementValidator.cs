using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapterComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public class WifiAdapterPlacementValidator : IComponentPlacementValidator
{
    private readonly IMotherBoard _motherBoard;
    private readonly IWifiAdapter? _wifiAdapter;

    public WifiAdapterPlacementValidator(IMotherBoard motherBoard, IWifiAdapter? wifiAdapter)
    {
        _motherBoard = motherBoard;
        _wifiAdapter = wifiAdapter;
    }

    public bool Validate(ref BuildResult result)
    {
        if (_wifiAdapter is not null && !_motherBoard.HasIntegratedWifiModule)
        {
            result = new BuildResult.BuildFail(
                "WiFi adapter cannot be placed on mother board because it already has wifi element");
            return false;
        }

        return true;
    }
}