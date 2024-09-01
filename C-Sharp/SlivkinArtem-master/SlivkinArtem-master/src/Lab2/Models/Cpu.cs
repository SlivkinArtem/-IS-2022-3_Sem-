using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Cpu : ICpu
{
    public Cpu(
        Socket? socket, 
        Tdp? tdp, 
        PowerConsumption? cpuPowerConsumption, 
        Frequency? coresFrequency, 
        Count? numberOfCores)
    {
        Tdp = tdp;
        CpuPowerConsumption = cpuPowerConsumption;
        CoresFrequency = coresFrequency;
        NumberOfCores = numberOfCores;
        Socket = socket;
    }
    
    public static CpuBuilder Builder => new CpuBuilder();
    public PowerConsumption? CpuPowerConsumption { get; }
    public Tdp? Tdp { get; }
    public Socket? Socket { get; }
    public Frequency? CoresFrequency { get; }
    public Count? NumberOfCores { get; }
}