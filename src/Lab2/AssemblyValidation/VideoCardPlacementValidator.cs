using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCaseComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ProcessorComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public class VideoCardPlacementValidator : IComponentPlacementValidator
{
    private readonly IComputerCase _computerCase;
    private readonly IProcessor _processor;
    private readonly IVideoCard? _videoCard;

    public VideoCardPlacementValidator(
        IComputerCase computerCase,
        IProcessor processor,
        IVideoCard? videoCard)
    {
        _computerCase = computerCase;
        _processor = processor;
        _videoCard = videoCard;
    }

    public bool Validate(ref BuildResult result)
    {
        if (_processor.HasIntegratedVideoCore is false && _videoCard is null)
        {
            result = new BuildResult.BuildFail(
                "Assembly cannot be build without video component");
            return false;
        }

        if (_videoCard is not null &&
            (_computerCase.MaxVideoCardDimensions.Height > _videoCard.Dimensions.Height ||
             _computerCase.MaxVideoCardDimensions.Width > _videoCard.Dimensions.Width))
        {
            result = new BuildResult.BuildFail(
                "Videocard cannot be placed in computer case because it has higher dimensions than it");
            return false;
        }

        return true;
    }
}