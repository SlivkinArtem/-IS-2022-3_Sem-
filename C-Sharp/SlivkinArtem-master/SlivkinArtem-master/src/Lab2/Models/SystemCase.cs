using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class SystemCase
{
    private readonly List<FormFactor>? _supportedMotherBoardFormFactors;
    public SystemCase(
        Dimensions? maxVideoCardDimensions, 
        Dimensions? dimensions, 
        IEnumerable<FormFactor>? supportedMotherBoardFormFactors)
    {
        MaxVideoCardDimensions = maxVideoCardDimensions;
        Dimensions = dimensions;
        if (supportedMotherBoardFormFactors != null)
            _supportedMotherBoardFormFactors = new List<FormFactor>(supportedMotherBoardFormFactors);
    }
    
    public static SystemCaseBuilder Builder => new SystemCaseBuilder();
    public Dimensions? MaxVideoCardDimensions { get; private set; }
    public Dimensions? Dimensions { get; private set; }
}