using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Ssd
{
    public Ssd(Capacity? capacity, PowerConsumption? ssdPowerConsumption, Speed? maxSpeed)
    {
        Capacity = capacity;
        SsdPowerConsumption = ssdPowerConsumption;
        MaxSpeed = maxSpeed;
    }

    public static SsdBuilder Builder => new SsdBuilder();
    public PowerConsumption? SsdPowerConsumption { get; }
    public Capacity? Capacity { get; private set; }
    public Speed? MaxSpeed { get; }
}