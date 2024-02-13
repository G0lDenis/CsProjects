using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class Display : IDisplay
{
    private readonly IDisplayDriver _driver;

    public Display(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void WriteText(string text, Color color)
    {
        _driver.ClearConsole();
        _driver.SetColor(color);
        _driver.WriteText(text);
    }
}