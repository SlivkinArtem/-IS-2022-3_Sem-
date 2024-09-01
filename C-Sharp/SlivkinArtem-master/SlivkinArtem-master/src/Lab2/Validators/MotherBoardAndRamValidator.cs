using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public static class MotherBoardAndRamValidator
{
    public static void ValidateDdr(MotherBoard? motherBoard, Ram? ram)
    {
        ArgumentNullException.ThrowIfNull(motherBoard?.Ddr);
        ArgumentNullException.ThrowIfNull(ram?.Ddr);
        if (motherBoard.Ddr.Standart != ram.Ddr.Standart)
            throw ComputerBuilderException.IncompatibleDdrStandartException();
    }
}