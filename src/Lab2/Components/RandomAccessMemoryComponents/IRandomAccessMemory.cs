using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.RandomAccessMemoryComponents;

public interface IRandomAccessMemory : IPrototype<RandomAccessMemory>
{
    public int RamSize { get; }

    public IEnumerable<JedecFrequencyFormat> SupportedJedecFormats { get; }

    public IEnumerable<XmpProfile> SupportedXmpProfiles { get; }

    public RamProfile Profile { get; }

    public DdrRamType Type { get; }

    public int Power { get; }
}