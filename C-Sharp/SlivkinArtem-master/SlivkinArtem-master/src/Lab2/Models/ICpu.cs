using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface ICpu
{
    public static CpuBuilder Builder => new CpuBuilder();
    public PowerConsumption? CpuPowerConsumption { get; }
    public Tdp? Tdp { get; }
    public Socket? Socket { get; }
}