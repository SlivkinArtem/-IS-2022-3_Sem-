using System;
namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComputerBuilderException : Exception
{
    private ComputerBuilderException(string message) 
        : base(message)
    {
    }

    private ComputerBuilderException()
    {
    }

    private ComputerBuilderException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }

    public static ComputerBuilderException IncompatibleCoolerTdpException()
    {
        return new ComputerBuilderException("Invalid tdp chars: cooler TDP is less then Cpu TDP");
    }

    public static ComputerBuilderException IncompatibleDimensionsException()
    {
        return new ComputerBuilderException("Dimensions are Incompatible");
    }

    public static ComputerBuilderException IncompatibleDdrStandartException()
    {
        return new ComputerBuilderException("Ddr Standarts are Different");
    }

    public static ComputerBuilderException IncompatibleSocketsException()
    {
        return new ComputerBuilderException("MotherBoard and Cpu sockets are Incompatible");
    }

    public static ComputerBuilderException IncompatibleCpuForMotherBoardException()
    {
        return new ComputerBuilderException("Cpu is not contains in supported cpus");
    }

    public static ComputerBuilderException CpuDoesNotHaveVideoCoreException()
    {
        return new ComputerBuilderException("Cpu doesn't have video core");
    }

    public static ComputerBuilderException PowerUnitMaxLoadLackException()
    {
        return new ComputerBuilderException("Too much power consumption");
    }

    public static ComputerBuilderException SsdOrHddAvailabilityException()
    {
        return new ComputerBuilderException("Computer should have hdd or ssd");
    }

    public static ComputerBuilderException RequiredСomponentsAvailabilityException()
    {
        return new ComputerBuilderException("Computer should have motherBoard, cpu, cooler, systemCase and powerUnit");
    }
}