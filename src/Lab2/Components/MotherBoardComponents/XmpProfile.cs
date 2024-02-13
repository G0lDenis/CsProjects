namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

public record XmpProfile : JedecFrequencyFormat
{
    public XmpProfile(int frequencyValue, int voltageValue)
        : base(frequencyValue, voltageValue)
    {
    }

    internal record Ticks(string TicksValue);
}