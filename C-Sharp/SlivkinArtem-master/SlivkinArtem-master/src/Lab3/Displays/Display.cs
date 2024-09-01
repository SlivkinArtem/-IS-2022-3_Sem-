using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }
    
    public void SetColor(Color color)
    {
        _displayDriver.SetColor(color);
    }

    public void Show(Message? message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _displayDriver.Show(message);
        Console.Clear();
    }
}