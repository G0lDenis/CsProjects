namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;

public record JedecFrequencyFormat
{
    public JedecFrequencyFormat(int frequencyValue, float voltageValue)
    {
        FrequencyValue = new Frequency(frequencyValue);
        VoltageValue = new Voltage(voltageValue);
    }

    public Frequency FrequencyValue { get; }

    public Voltage VoltageValue { get; }
}