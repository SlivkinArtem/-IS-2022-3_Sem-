using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public static class MotherBoardAndCpuValidator
{
    public static void ValidateSockets(MotherBoard? motherBoard, Cpu? cpu)
    {
        ArgumentNullException.ThrowIfNull(motherBoard?.Socket);
        ArgumentNullException.ThrowIfNull(cpu?.Socket);
        if (motherBoard.Socket.SocketName != cpu.Socket.SocketName)
            throw ComputerBuilderException.IncompatibleSocketsException();
    }

    public static void ValidateContainingCpuInSupportedCpusList(Cpu? cpu, Bios? bios)
    {
        ArgumentNullException.ThrowIfNull(bios);
        ArgumentNullException.ThrowIfNull(bios.SupportedCpus);
        ArgumentNullException.ThrowIfNull(cpu);
        if (!bios.SupportedCpus.Contains(cpu)) throw ComputerBuilderException.IncompatibleCpuForMotherBoardException();
    }
}