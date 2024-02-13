using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.ProcessorComponents;

public class Processor : IProcessor
{
    private Processor(
        string name,
        Socket supportedSocket,
        IEnumerable<Frequency> supportedFrequencies,
        int coreFrequency,
        int coreNumber,
        bool hasIntegratedVideoCore,
        int heatMass,
        int power,
        int minimumRecommendedPower)
    {
        Name = name;
        SupportedSocket = supportedSocket;
        SupportedFrequencies = supportedFrequencies;
        CoreFrequency = coreFrequency;
        CoreNumber = coreNumber;
        HasIntegratedVideoCore = hasIntegratedVideoCore;
        HeatMass = heatMass;
        Power = power;
        MinimumRecommendedPower = minimumRecommendedPower;
    }

    public string Name { get; }

    public Socket SupportedSocket { get; }

    public IEnumerable<Frequency> SupportedFrequencies { get; }

    public int CoreFrequency { get; }

    public int CoreNumber { get; }

    public bool HasIntegratedVideoCore { get; }

    public int HeatMass { get; }

    public int Power { get; }

    public int MinimumRecommendedPower { get; }

    public Processor Clone()
    {
        return new Processor(
            Name,
            SupportedSocket,
            SupportedFrequencies,
            CoreFrequency,
            CoreNumber,
            HasIntegratedVideoCore,
            HeatMass,
            Power,
            MinimumRecommendedPower);
    }

    public class ProcessorBuilder
    {
        private string? _name;
        private Socket? _supportedSocket;
        private IEnumerable<Frequency>? _supportedFrequencies;
        private int? _coreFrequency;
        private int? _coreNumber;
        private bool? _hasIntegratedVideoCore;
        private int? _heatMass;
        private int? _power;
        private int? _minimumRecommendedPower;

        public ProcessorBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ProcessorBuilder WithSupportedSocket(Socket socket)
        {
            _supportedSocket = socket;
            return this;
        }

        public ProcessorBuilder WithSupportedFrequencies(IEnumerable<Frequency> supportedFrequencies)
        {
            _supportedFrequencies = supportedFrequencies;
            return this;
        }

        public ProcessorBuilder WithCoreFrequency(int coreFrequency)
        {
            _coreFrequency = coreFrequency;
            return this;
        }

        public ProcessorBuilder WithCoreNumber(int coreNumber)
        {
            _coreNumber = coreNumber;
            return this;
        }

        public ProcessorBuilder WithHasIntegratedVideoCore(bool hasIntegratedVideoCore)
        {
            _hasIntegratedVideoCore = hasIntegratedVideoCore;
            return this;
        }

        public ProcessorBuilder WithHeatMass(int heatMass)
        {
            _heatMass = heatMass;
            return this;
        }

        public ProcessorBuilder WithPower(int power)
        {
            _power = power;
            return this;
        }

        public ProcessorBuilder WithMinimumRecommendedPower(int minimumRecommendedPower)
        {
            _minimumRecommendedPower = minimumRecommendedPower;
            return this;
        }

        public Processor Build()
        {
            return new Processor(
                _name ?? throw new ComponentBuilderException("Processor name cannot be empty"),
                _supportedSocket ?? throw new ComponentBuilderException("Processor socket cannot be empty"),
                _supportedFrequencies is null || !_supportedFrequencies.Any() ? throw new ComponentBuilderException("Processor supported frequencies cannot be empty") : _supportedFrequencies,
                _coreFrequency ?? throw new ComponentBuilderException("Processor core frequency cannot be empty"),
                _coreNumber ?? throw new ComponentBuilderException("Processor core number cannot be empty"),
                _hasIntegratedVideoCore ?? false,
                _heatMass ?? throw new ComponentBuilderException("Processor heat mass cannot be empty"),
                _power ?? throw new ComponentBuilderException("Processor power cannot be empty"),
                _minimumRecommendedPower ?? throw new ComponentBuilderException("Processor minimum recommended power cannot be empty"));
        }
    }
}