using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Hdd
{
    public Hdd(Capacity? capacity, PowerConsumption? hddPowerConsumption, Speed? spindleSpeed)
    {
        Capacity = capacity;
        HddPowerConsumption = hddPowerConsumption;
        SpindleSpeed = spindleSpeed;
    }
    
    public static HddBuilder Builder => new HddBuilder();
    public PowerConsumption? HddPowerConsumption { get; private set; }
    public Capacity? Capacity { get; private set; }
    public Speed? SpindleSpeed { get; }
}