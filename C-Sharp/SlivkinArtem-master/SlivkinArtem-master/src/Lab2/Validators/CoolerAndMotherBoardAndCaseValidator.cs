using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public static class CoolerAndMotherBoardAndCaseValidator
{
    public static void ValidateCapacityOfCoolerWithMotherBoardInTheSystemCase(MotherBoard? motherBoard, Cooler? cooler, SystemCase? systemCase)
    {
        ArgumentNullException.ThrowIfNull(cooler?.Dimensions);
        ArgumentNullException.ThrowIfNull(motherBoard?.Dimensions);
        ArgumentNullException.ThrowIfNull(systemCase?.Dimensions);
        if (((cooler.Dimensions.Length * cooler.Dimensions.Height) +
             (motherBoard.Dimensions.Length * motherBoard.Dimensions.Height)) > (systemCase.Dimensions.Length *
                systemCase.Dimensions.Height)) throw ComputerBuilderException.IncompatibleDimensionsException();
    }
}