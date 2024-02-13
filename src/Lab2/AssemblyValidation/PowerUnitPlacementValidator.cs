using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnitComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ProcessorComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.RandomAccessMemoryComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapterComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public class PowerUnitPlacementValidator : IComponentPlacementValidator
{
    private readonly IProcessor _processor;
    private readonly IVideoCard? _videoCard;
    private readonly IEnumerable<IRandomAccessMemory> _randomAccessMemoryElements;
    private readonly IWifiAdapter? _wifiAdapter;
    private readonly IPowerUnit _powerUnit;

    public PowerUnitPlacementValidator(
        IProcessor processor,
        IVideoCard? videoCard,
        IEnumerable<IRandomAccessMemory> randomAccessMemoryElements,
        IWifiAdapter? wifiAdapter,
        IPowerUnit powerUnit)
    {
        _processor = processor;
        _videoCard = videoCard;
        _randomAccessMemoryElements = randomAccessMemoryElements;
        _wifiAdapter = wifiAdapter;
        _powerUnit = powerUnit;
    }

    public bool Validate(ref BuildResult result)
    {
        if (_processor.MinimumRecommendedPower > _powerUnit.MaxPower)
        {
            result = new BuildResult.BuildFail(
                "Power unit has less power than processor need");
            return false;
        }

        if (_videoCard is not null && _videoCard.MinimumRecommendedPower > _powerUnit.MaxPower)
        {
            result = new BuildResult.BuildFail(
                "Power unit has less power than videocard need");
            return false;
        }

        if (_powerUnit.MaxPower <
            _processor.Power
            + (_videoCard?.Power ?? 0)
            + _randomAccessMemoryElements.Sum(randomAccessMemory => randomAccessMemory.Power)
            + (_wifiAdapter?.Power ?? 0))
        {
            ((BuildResult.BuildSuccess)result).AddMessage("Power unit has less power than assembly need");
        }

        return true;
    }
}