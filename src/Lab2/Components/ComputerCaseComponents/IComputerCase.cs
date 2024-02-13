using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCaseComponents;

public interface IComputerCase : IPrototype<ComputerCase>
{
    public VideoCardDimensions MaxVideoCardDimensions { get; }

    public MotherFormFactor SupportedMotherFormFactor { get; }

    public ComputerCaseDimensions Dimensions { get; }

    public int CoolerMaxHeight { get; }
}