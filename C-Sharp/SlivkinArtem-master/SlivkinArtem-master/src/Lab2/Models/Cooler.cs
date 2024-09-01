using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Cooler
{
    private IEnumerable<Socket?>? _supportedSockets;
    public Cooler(Dimensions? dimensions, IEnumerable<Socket?> supportedSockets, Tdp? tdp)
    {
        Dimensions = dimensions;
        _supportedSockets = supportedSockets;  
        Tdp = tdp;
    }
    
    public static CoolerBuilder Builder => new CoolerBuilder();
    public Tdp? Tdp { get; }
    public Dimensions? Dimensions { get; }
}