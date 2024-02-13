using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CoolerSystemComponents;

public interface ICoolerSystem : IPrototype<CoolerSystem>
{
    public int Weight { get; }

    public IEnumerable<Socket> SupportedSockets { get; }

    public int MaxNeutralizedHeatMass { get; }
}