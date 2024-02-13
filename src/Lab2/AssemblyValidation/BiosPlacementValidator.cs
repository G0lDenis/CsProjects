using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.BiosComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ProcessorComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public class BiosPlacementValidator : IComponentPlacementValidator
{
    private readonly IMotherBoard _motherBoard;
    private readonly IProcessor _processor;
    private readonly IBios _bios;

    public BiosPlacementValidator(IMotherBoard motherBoard, IProcessor processor, IBios bios)
    {
        _motherBoard = motherBoard;
        _processor = processor;
        _bios = bios;
    }

    public bool Validate(ref BuildResult result)
    {
        if (!_motherBoard.SupportedBiosTypes.Contains(_bios.Type))
        {
            result = new BuildResult.BuildFail(
                "Bios cannot be placed in on mother board because mother board doesn't support it");
            return false;
        }

        if (!_bios.SupportedProcessors.Contains(_processor.Name))
        {
            result = new BuildResult.BuildFail(
                "Bios doesn't support this processor");
            return false;
        }

        return true;
    }
}