using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public static class AssemblingValidator
{
    public static void ValidateCpuVideoCoreAvailability(ICpu? cpu, bool videoCardIsNull)
    {
        ArgumentNullException.ThrowIfNull(cpu);
        if (cpu is not CpuWithVideoCore && videoCardIsNull) throw ComputerBuilderException.CpuDoesNotHaveVideoCoreException();
    }

    public static void ValidatePowerUnitMaxLoad(PowerUnit? powerUnit, Computer? computer)
    {
        ArgumentNullException.ThrowIfNull(powerUnit?.MaxLoad);
        ArgumentNullException.ThrowIfNull(computer?.PowerConsumption);
        if (powerUnit.MaxLoad.Watt <= computer.PowerConsumption.Value)
            throw ComputerBuilderException.PowerUnitMaxLoadLackException();
    }

    public static void ValidateSsdOrHddAvailability(Ssd? ssd, Hdd? hdd)
    {
        if (ssd == null || hdd == null) throw ComputerBuilderException.SsdOrHddAvailabilityException();
    }

    public static void ValidateRequiredСomponentsAvailability(MotherBoard? motherBoard, Cpu? cpu, Cooler? cooler, SystemCase? systemCase, PowerUnit? powerUnit)
    {
        if (motherBoard == null || cpu == null || cooler == null || systemCase == null || powerUnit == null) throw ComputerBuilderException.RequiredСomponentsAvailabilityException();
    }
}