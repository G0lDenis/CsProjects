using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class DisplayDriver : IDisplayDriver
{
    private readonly IOutputWriter _writer;
    private Color _color;

    public DisplayDriver(IOutputWriter writer)
    {
        _writer = writer;
    }

    public void ClearConsole()
    {
        _writer.ClearOutput();
    }

    public void WriteText(string text)
    {
        _writer.WriteText(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text));
    }

    public void SetColor(Color color)
    {
        _color = color;
    }
}