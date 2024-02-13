using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCaseComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public class MotherBoardPlacementValidator : IComponentPlacementValidator
{
    private readonly IComputerCase _computerCase;
    private readonly IMotherBoard _motherBoard;

    public MotherBoardPlacementValidator(IComputerCase computerCase, IMotherBoard motherBoard)
    {
        _computerCase = computerCase;
        _motherBoard = motherBoard;
    }

    public bool Validate(ref BuildResult result)
    {
        if (_computerCase.SupportedMotherFormFactor != _motherBoard.FormFactor)
        {
            result = new BuildResult.BuildFail(
                "Mother board cannot be placed in computer case because of different form-factors");
            return false;
        }

        return true;
    }
}