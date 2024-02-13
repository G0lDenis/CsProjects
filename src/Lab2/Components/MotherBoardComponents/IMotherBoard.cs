using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

public interface IMotherBoard : IPrototype<MotherBoard>
{
    public Socket SupportedSocket { get; }

    public IDictionary<PciLine, int> PciLines { get; }

    public int SataPortNumber { get; }

    public IEnumerable<XmpProfile> SupportedXmpProfiles { get; }

    public IEnumerable<JedecFrequencyFormat> SupportedJedecFormats { get; }

    public DdrRamType SupportedDdrRamType { get; }

    public IDictionary<RamProfile, int> AvailableRamSocketTypes { get; }

    public MotherFormFactor FormFactor { get; }

    public IEnumerable<BiosType> SupportedBiosTypes { get; }

    public bool HasIntegratedWifiModule { get; }
}