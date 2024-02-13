using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public interface IDisplay
{
    void WriteText(string text, Color color);
}