using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public interface IDisplayDriver
{
    void ClearConsole();

    void WriteText(string text);

    void SetColor(Color color);
}