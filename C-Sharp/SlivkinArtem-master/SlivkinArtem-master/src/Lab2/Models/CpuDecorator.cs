using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public abstract class CpuDecorator : ICpu
{
    private ICpu _cpu;

    protected CpuDecorator(ICpu cpu)
    {
        _cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
        CpuPowerConsumption = cpu.CpuPowerConsumption;
        Tdp = cpu.Tdp;
        Socket = cpu.Socket;
    }

    public PowerConsumption? CpuPowerConsumption { get; }
    public Tdp? Tdp { get; }
    public Socket? Socket { get; }
}