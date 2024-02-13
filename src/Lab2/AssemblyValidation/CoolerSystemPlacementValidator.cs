using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCaseComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.CoolerSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ProcessorComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public class CoolerSystemPlacementValidator : IComponentPlacementValidator
{
    private readonly IComputerCase _computerCase;
    private readonly IMotherBoard _motherBoard;
    private readonly IProcessor _processor;
    private readonly ICoolerSystem _coolerSystem;

    public CoolerSystemPlacementValidator(
        IComputerCase computerCase,
        IMotherBoard motherBoard,
        IProcessor processor,
        ICoolerSystem coolerSystem)
    {
        _computerCase = computerCase;
        _motherBoard = motherBoard;
        _processor = processor;
        _coolerSystem = coolerSystem;
    }

    public bool Validate(ref BuildResult result)
    {
        if (result == null) throw new ArgumentNullException(nameof(result));
        if (_coolerSystem.Weight > _computerCase.CoolerMaxHeight)
        {
            result = new BuildResult.BuildFail(
                "Cooler system cannot be placed in computer case because it exceeds its maximum cooler size");

            return false;
        }

        if (!_coolerSystem.SupportedSockets.Contains(_motherBoard.SupportedSocket))
        {
            result = new BuildResult.BuildFail(
                "Cooler system cannot be placed in on mother board because it doesn't support its socket");

            return false;
        }

        if (_coolerSystem.MaxNeutralizedHeatMass < _processor.HeatMass)
        {
            if (result is not BuildResult.BuildWithoutWarrantySuccess)
            {
                result = new BuildResult.BuildWithoutWarrantySuccess((BuildResult.BuildSuccess)result);
            }

            ((BuildResult.BuildWithoutWarrantySuccess)result).AddMessage(
                "Cooler heat mass that can be neutralized is less than processor heat mass");
        }

        return true;
    }
}