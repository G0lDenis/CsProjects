using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CoolerSystemComponents;

public class CoolerSystem : ICoolerSystem
{
    private CoolerSystem(string name, int weight, IEnumerable<Socket> supportedSockets, int maxNeutralizedHeatMass)
    {
        Name = name;
        Weight = weight;
        SupportedSockets = supportedSockets;
        MaxNeutralizedHeatMass = maxNeutralizedHeatMass;
    }

    public string Name { get; }

    public int Weight { get; }

    public IEnumerable<Socket> SupportedSockets { get; }

    public int MaxNeutralizedHeatMass { get; }

    public CoolerSystem Clone()
    {
        return new CoolerSystem(
            Name,
            Weight,
            SupportedSockets,
            MaxNeutralizedHeatMass);
    }

    public class CoolerSystemBuilder
    {
        private string? _name;
        private int? _weight;
        private IEnumerable<Socket>? _supportedSockets;
        private int? _maxNeutralizedHeatMass;

        public CoolerSystemBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CoolerSystemBuilder WithWeight(int weight)
        {
            _weight = weight;
            return this;
        }

        public CoolerSystemBuilder WithSupportedSockets(IEnumerable<Socket> supportedSockets)
        {
            _supportedSockets = supportedSockets;
            return this;
        }

        public CoolerSystemBuilder WithMaxNeutralizedHeatMass(int maxNeutralizedHeatMass)
        {
            _maxNeutralizedHeatMass = maxNeutralizedHeatMass;
            return this;
        }

        public CoolerSystem Build()
        {
            return new CoolerSystem(
                _name ?? throw new ComponentBuilderException("Cooler system name cannot be empty"),
                _weight ?? throw new ComponentBuilderException("Cooler system weight cannot be empty"),
                _supportedSockets is null || !_supportedSockets.Any() ? throw new ComponentBuilderException("Cooler system supported sockets cannot be empty") : _supportedSockets,
                _maxNeutralizedHeatMass ?? throw new ComponentBuilderException("Cooler system max neutralized heat mass cannot be empty"));
        }
    }
}