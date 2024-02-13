using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

public class MotherBoard : IMotherBoard
{
    private MotherBoard(
        string name,
        Socket socket,
        IDictionary<PciLine, int> pciLines,
        int sataPortNumber,
        IEnumerable<XmpProfile> supportedXmpProfiles,
        IEnumerable<JedecFrequencyFormat> supportedJedecFormats,
        DdrRamType supportedDdrRamType,
        IDictionary<RamProfile, int> availableRamSocketTypes,
        MotherFormFactor formFactor,
        IEnumerable<BiosType> supportedBiosTypes,
        bool hasIntegratedWifiModule)
    {
        Name = name;
        SupportedSocket = socket;
        PciLines = pciLines;
        SataPortNumber = sataPortNumber;
        SupportedXmpProfiles = supportedXmpProfiles;
        SupportedJedecFormats = supportedJedecFormats;
        SupportedDdrRamType = supportedDdrRamType;
        AvailableRamSocketTypes = availableRamSocketTypes;
        FormFactor = formFactor;
        SupportedBiosTypes = supportedBiosTypes;
        HasIntegratedWifiModule = hasIntegratedWifiModule;
    }

    public string Name { get; }

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

    public MotherBoard Clone()
    {
        return new MotherBoard(
            Name,
            SupportedSocket,
            PciLines,
            SataPortNumber,
            SupportedXmpProfiles,
            SupportedJedecFormats,
            SupportedDdrRamType,
            AvailableRamSocketTypes,
            FormFactor,
            SupportedBiosTypes,
            HasIntegratedWifiModule);
    }

    public class MotherBoardBuilder
    {
        private string? _name;
        private Socket? _socket;
        private IDictionary<PciLine, int>? _pciLines;
        private int? _sataPortNumber;
        private IEnumerable<XmpProfile>? _supportedXmpProfiles;
        private IEnumerable<JedecFrequencyFormat>? _supportedJedecFormats;
        private DdrRamType? _supportedDdrRamType;
        private IDictionary<RamProfile, int>? _availableRamSocketTypes;
        private MotherFormFactor? _formFactor;
        private IEnumerable<BiosType>? _supportedBiosTypes;
        private bool? _hasIntegratedWifiModule;

        public MotherBoardBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public MotherBoardBuilder WithSocket(Socket socket)
        {
            _socket = socket;
            return this;
        }

        public MotherBoardBuilder WithPciLines(IDictionary<PciLine, int> pciLines)
        {
            _pciLines = pciLines;
            return this;
        }

        public MotherBoardBuilder WithSataPortNumber(int sataPortNumber)
        {
            _sataPortNumber = sataPortNumber;
            return this;
        }

        public MotherBoardBuilder WithSupportedXmpProfiles(IEnumerable<XmpProfile> supportedXmpProfiles)
        {
            _supportedXmpProfiles = supportedXmpProfiles;
            return this;
        }

        public MotherBoardBuilder WithSupportedJedecFormats(IEnumerable<JedecFrequencyFormat> supportedJedecFormats)
        {
            _supportedJedecFormats = supportedJedecFormats;
            return this;
        }

        public MotherBoardBuilder WithSupportedDdrRamType(DdrRamType supportedDdrRamType)
        {
            _supportedDdrRamType = supportedDdrRamType;
            return this;
        }

        public MotherBoardBuilder WithAvailableRamSocketTypes(IDictionary<RamProfile, int> availableRamSocketTypes)
        {
            _availableRamSocketTypes = availableRamSocketTypes;
            return this;
        }

        public MotherBoardBuilder WithFormFactor(MotherFormFactor formFactor)
        {
            _formFactor = formFactor;
            return this;
        }

        public MotherBoardBuilder WithSupportedBiosTypes(IEnumerable<BiosType> supportedBiosTypes)
        {
            _supportedBiosTypes = supportedBiosTypes;
            return this;
        }

        public MotherBoardBuilder WithHasIntegratedWifiModule(bool hasIntegratedWifiModule)
        {
            _hasIntegratedWifiModule = hasIntegratedWifiModule;
            return this;
        }

        public MotherBoard Build()
        {
            return new MotherBoard(
                _name ?? throw new ComponentBuilderException("Mother board name cannot be empty"),
                _socket ?? throw new ComponentBuilderException("Mother board socket cannot be empty"),
                _pciLines is null || !_pciLines.Any() ? throw new ComponentBuilderException("Mother board PCI lines cannot be empty") : _pciLines,
                _sataPortNumber ?? 0,
                _supportedXmpProfiles ?? new List<XmpProfile>(),
                _supportedJedecFormats is null || !_supportedJedecFormats.Any() ? throw new ComponentBuilderException("Mother board Jedec formats cannot be empty") : _supportedJedecFormats,
                _supportedDdrRamType ?? throw new ComponentBuilderException("Mother board RAM type cannot be empty"),
                _availableRamSocketTypes is null || !_availableRamSocketTypes.Any() ? throw new ComponentBuilderException("Mother board available RAM socket types cannot be empty") : _availableRamSocketTypes,
                _formFactor ?? throw new ComponentBuilderException("Mother board form-factor cannot be empty"),
                _supportedBiosTypes is null || !_supportedBiosTypes.Any() ? throw new ComponentBuilderException("Mother board supported BIOS cannot be empty") : _supportedBiosTypes,
                _hasIntegratedWifiModule ?? false);
        }
    }
}