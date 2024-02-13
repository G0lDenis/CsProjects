using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.BiosComponents;

public interface IBios : IPrototype<Bios>
{
    public BiosType Type { get; }

    public IEnumerable<string> SupportedProcessors { get; }
}