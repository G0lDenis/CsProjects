using System.Collections.Generic;
using System.Data;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.RandomAccessMemoryComponents;

public class RandomAccessMemory : IRandomAccessMemory
{
    private RandomAccessMemory(
        string name,
        int ramSize,
        IEnumerable<JedecFrequencyFormat> supportedJedecFormats,
        IEnumerable<XmpProfile> supportedXmpProfiles,
        RamProfile profile,
        DdrRamType type,
        int power)
    {
        Name = name;
        RamSize = ramSize;
        SupportedJedecFormats = supportedJedecFormats;
        SupportedXmpProfiles = supportedXmpProfiles;
        Profile = profile;
        Type = type;
        Power = power;
    }

    public string Name { get; }

    public int RamSize { get; }

    public IEnumerable<JedecFrequencyFormat> SupportedJedecFormats { get; }

    public IEnumerable<XmpProfile> SupportedXmpProfiles { get; }

    public RamProfile Profile { get; }

    public DdrRamType Type { get; }

    public int Power { get; }

    public RandomAccessMemory Clone()
    {
        return new RandomAccessMemory(
            Name,
            RamSize,
            SupportedJedecFormats,
            SupportedXmpProfiles,
            Profile,
            Type,
            Power);
    }

    public class RandomAccessMemoryBuilder
    {
        private string? _name;
        private int? _ramSize;
        private IEnumerable<JedecFrequencyFormat>? _supportedJedecFormats;
        private IEnumerable<XmpProfile>? _supportedXmpProfiles;
        private RamProfile? _profile;
        private DdrRamType? _type;
        private int? _power;

        public RandomAccessMemoryBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public RandomAccessMemoryBuilder WithRamSize(int ramSize)
        {
            _ramSize = ramSize;
            return this;
        }

        public RandomAccessMemoryBuilder WithSupportedJedecFormats(
            IEnumerable<JedecFrequencyFormat> supportedJedecFormats)
        {
            _supportedJedecFormats = supportedJedecFormats;
            return this;
        }

        public RandomAccessMemoryBuilder WithSupportedXmpProfiles(
            IEnumerable<XmpProfile> supportedXmpProfiles)
        {
            _supportedXmpProfiles = supportedXmpProfiles;
            return this;
        }

        public RandomAccessMemoryBuilder WithProfile(RamProfile profile)
        {
            _profile = profile;
            return this;
        }

        public RandomAccessMemoryBuilder WithType(DdrRamType type)
        {
            _type = type;
            return this;
        }

        public RandomAccessMemoryBuilder WithPower(int power)
        {
            _power = power;
            return this;
        }

        public RandomAccessMemory Build()
        {
            return new RandomAccessMemory(
                _name ?? throw new ConstraintException("Random access memory name cannot be empty"),
                _ramSize ?? throw new ConstraintException("Random access memory size cannot be empty"),
                _supportedJedecFormats is null || !_supportedJedecFormats.Any() ? throw new ComponentBuilderException("Random access memory supported Jedec formats cannot be empty") : _supportedJedecFormats,
                _supportedXmpProfiles ?? new List<XmpProfile>(),
                _profile ?? throw new ConstraintException("Random access memory profile cannot be empty"),
                _type ?? throw new ConstraintException("Random access memory type cannot be empty"),
                _power ?? throw new ConstraintException("Random access memory power cannot be empty"));
        }
    }
}