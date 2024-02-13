using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.ProcessorComponents;

public interface IProcessor : IPrototype<Processor>
{
    public Socket SupportedSocket { get; }

    public IEnumerable<Frequency> SupportedFrequencies { get; }

    public int CoreFrequency { get; }

    public int CoreNumber { get; }

    public bool HasIntegratedVideoCore { get; }

    public int HeatMass { get; }

    public int Power { get; }

    public int MinimumRecommendedPower { get; }
}