using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCardComponents;

public interface IVideoCard : IPrototype<VideoCard>
{
    public VideoCardDimensions Dimensions { get; }

    public int ChipFrequency { get; }

    public int Memory { get; }

    public PciLine PciLine { get; }

    public int Power { get; }

    public int MinimumRecommendedPower { get; }
}