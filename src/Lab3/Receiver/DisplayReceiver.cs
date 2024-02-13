using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Display;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receiver;

public class DisplayReceiver : IReceiver
{
    private readonly IDisplay _display;

    public DisplayReceiver(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(Message message)
    {
        Color color = message.Priority switch
        {
            < 2 => Color.DarkBlue,
            >= 2 and <= 3 => Color.DarkGreen,
            > 3 => Color.DarkRed,
        };
        _display.WriteText(new MessageRenderer(message).Render(), color);
    }
}