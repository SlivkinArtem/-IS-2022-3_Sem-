using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public static class CoolerAndCpuValidator
{
    public static void ValidateTdp(Cpu? cpu, Cooler? cooler)
    {
        ArgumentNullException.ThrowIfNull(cooler?.Tdp);
        ArgumentNullException.ThrowIfNull(cpu?.Tdp);
        if (cooler.Tdp.Mass < cpu.Tdp.Mass)
            throw ComputerBuilderException.IncompatibleCoolerTdpException();
    }
}