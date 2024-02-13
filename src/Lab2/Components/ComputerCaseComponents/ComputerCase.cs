using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCaseComponents;

public class ComputerCase : IComputerCase
{
    private ComputerCase(
        string name,
        VideoCardDimensions maxVideoCardDimensions,
        MotherFormFactor supportedMotherFormFactor,
        ComputerCaseDimensions dimensions,
        int coolerMaxHeight)
    {
        Name = name;
        MaxVideoCardDimensions = maxVideoCardDimensions;
        SupportedMotherFormFactor = supportedMotherFormFactor;
        Dimensions = dimensions;
        CoolerMaxHeight = coolerMaxHeight;
    }

    public string Name { get; }

    public VideoCardDimensions MaxVideoCardDimensions { get; }

    public MotherFormFactor SupportedMotherFormFactor { get; }

    public ComputerCaseDimensions Dimensions { get; }

    public int CoolerMaxHeight { get; }

    public ComputerCase Clone()
    {
        return new ComputerCase(
            Name,
            MaxVideoCardDimensions,
            SupportedMotherFormFactor,
            Dimensions,
            CoolerMaxHeight);
    }

    public class ComputerCaseBuilder
    {
        private string? _name;
        private VideoCardDimensions? _maxVideoCardDimensions;
        private MotherFormFactor? _supportedMotherFormFactor;
        private ComputerCaseDimensions? _dimensions;
        private int? _coolerMaxHeight;

        public ComputerCaseBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ComputerCaseBuilder WithMaxVideoCardDimensions(VideoCardDimensions maxVideoCardDimensions)
        {
            _maxVideoCardDimensions = maxVideoCardDimensions;
            return this;
        }

        public ComputerCaseBuilder WithSupportedMotherFormFactor(MotherFormFactor supportedMotherFormFactor)
        {
            _supportedMotherFormFactor = supportedMotherFormFactor;
            return this;
        }

        public ComputerCaseBuilder WithDimensions(ComputerCaseDimensions dimensions)
        {
            _dimensions = dimensions;
            return this;
        }

        public ComputerCaseBuilder WithCoolerMaxHeight(int coolerMaxHeight)
        {
            _coolerMaxHeight = coolerMaxHeight;
            return this;
        }

        public ComputerCase Build()
        {
            return new ComputerCase(
                _name ?? throw new ComponentBuilderException("Computer case name cannot be empty"),
                _maxVideoCardDimensions ?? throw new ComponentBuilderException("Computer case videocard dimensions cannot be empty"),
                _supportedMotherFormFactor ?? throw new ComponentBuilderException("Computer case supported mother form-factor cannot be empty"),
                _dimensions ?? throw new ComponentBuilderException("Computer case dimensions cannot be empty"),
                _coolerMaxHeight ?? throw new ComponentBuilderException("Computer case cooler max height cannot be empty"));
        }
    }
}