using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriver : IDisplayDriver
{
    private Color _color;
    public void SetColor(Color color)
    {
        _color = color;
    }

    public void Show(Message? message)
    {
        ArgumentNullException.ThrowIfNull(message);
        string coloredText = Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(message.Body);
        Console.WriteLine(coloredText);
    }
}