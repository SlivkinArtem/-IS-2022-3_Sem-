using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class PowerUnit
{
    public PowerUnit(Load? maxLoad)
    {
        MaxLoad = maxLoad;
    }

    public Load? MaxLoad { get; }
}