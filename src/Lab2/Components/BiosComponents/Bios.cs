using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.BiosComponents;

public class Bios : IBios
{
    private Bios(string name, BiosType type, IEnumerable<string> supportedProcessors)
    {
        Name = name;
        Type = type;
        SupportedProcessors = supportedProcessors;
    }

    public string Name { get; }

    public BiosType Type { get; }

    public IEnumerable<string> SupportedProcessors { get; }

    public Bios Clone()
    {
        return new Bios(Name, Type, SupportedProcessors);
    }

    public class BiosBuilder
    {
        private string? _name;
        private BiosType? _type;
        private IEnumerable<string>? _supportedProcessors;

        public BiosBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public BiosBuilder WithType(BiosType type)
        {
            _type = type;
            return this;
        }

        public BiosBuilder WithSupportedProcessors(IEnumerable<string> supportedProcessors)
        {
            _supportedProcessors = supportedProcessors;
            return this;
        }

        public Bios Build()
        {
            return new Bios(
                _name ?? throw new ComponentBuilderException("Bios name cannot be empty"),
                _type ?? throw new ComponentBuilderException("Bios type cannot be empty"),
                _supportedProcessors is null || !_supportedProcessors.Any() ? throw new ComponentBuilderException("Bios supported processors cannot be empty") : _supportedProcessors);
        }
    }
}