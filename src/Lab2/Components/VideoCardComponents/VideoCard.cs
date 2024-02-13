using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCardComponents;

public class VideoCard : IVideoCard
{
    private VideoCard(
        string name,
        VideoCardDimensions dimensions,
        int chipFrequency,
        int memory,
        PciLine pciLine,
        int power,
        int minimumRecommendedPower)
    {
        Name = name;
        Dimensions = dimensions;
        ChipFrequency = chipFrequency;
        Memory = memory;
        PciLine = pciLine;
        Power = power;
        MinimumRecommendedPower = minimumRecommendedPower;
    }

    public string Name { get; }

    public VideoCardDimensions Dimensions { get; }

    public int ChipFrequency { get; }

    public int Memory { get; }

    public PciLine PciLine { get; }

    public int Power { get; }

    public int MinimumRecommendedPower { get; }

    public VideoCard Clone()
    {
        return new VideoCard(
            Name,
            Dimensions,
            ChipFrequency,
            Memory,
            PciLine,
            Power,
            MinimumRecommendedPower);
    }

    public class VideoCardBuilder
    {
        private string? _name;
        private VideoCardDimensions? _dimensions;
        private int? _chipFrequency;
        private int? _memory;
        private PciLine? _pciLine;
        private int? _power;
        private int? _minimumRecommendedPower;

        public VideoCardBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public VideoCardBuilder WithDimensions(VideoCardDimensions videoCardDimensions)
        {
            _dimensions = videoCardDimensions;
            return this;
        }

        public VideoCardBuilder WithChipFrequency(int chipFrequency)
        {
            _chipFrequency = chipFrequency;
            return this;
        }

        public VideoCardBuilder WithMemory(int memory)
        {
            _memory = memory;
            return this;
        }

        public VideoCardBuilder WithPciLine(PciLine pciLine)
        {
            _pciLine = pciLine;
            return this;
        }

        public VideoCardBuilder WithPower(int power)
        {
            _power = power;
            return this;
        }

        public VideoCardBuilder WithMinimumRecommendedPower(int minimumRecommendedPower)
        {
            _minimumRecommendedPower = minimumRecommendedPower;
            return this;
        }

        public VideoCard Build()
        {
            return new VideoCard(
                _name ?? throw new ComponentBuilderException("Videocard name cannot be empty"),
                _dimensions ?? throw new ComponentBuilderException("Videocard dimensions cannot be empty"),
                _chipFrequency ?? throw new ComponentBuilderException("Videocard chip frequency name cannot be empty"),
                _memory ?? throw new ComponentBuilderException("Videocard memory cannot be empty"),
                _pciLine ?? throw new ComponentBuilderException("Videocard PCI line name cannot be empty"),
                _power ?? throw new ComponentBuilderException("Videocard power cannot be empty"),
                _minimumRecommendedPower ?? throw new ComponentBuilderException("Videocard minimum recommended power cannot be empty"));
        }
    }
}