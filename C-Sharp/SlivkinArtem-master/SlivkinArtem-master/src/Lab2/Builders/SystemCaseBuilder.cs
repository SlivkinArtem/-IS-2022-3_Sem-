using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SystemCaseBuilder
{
    private ICollection<FormFactor>? _supportedMotherBoardFormFactors;
    private Dimensions? _dimensions;
    private Dimensions? _maxVideoCardDimensions;
    
    public SystemCaseBuilder SetDimensions(Dimensions? dimensions)
    {
        ArgumentNullException.ThrowIfNull(dimensions);
        this._dimensions = dimensions;
        return this;
    }
    
    public SystemCaseBuilder SetMaxVideoCardDimensions(Dimensions? maxVideoCardDimensions)
    {
        ArgumentNullException.ThrowIfNull(maxVideoCardDimensions);
        this._maxVideoCardDimensions = maxVideoCardDimensions;
        return this;
    }
    
    public SystemCaseBuilder SetSupportedMotherBoardFormFactors(ICollection<FormFactor>? supportedMotherBoardFormFactors)
    {
        ArgumentNullException.ThrowIfNull(supportedMotherBoardFormFactors);
        this._supportedMotherBoardFormFactors = supportedMotherBoardFormFactors;
        return this;
    }

    public SystemCase Build()
    {
        return new SystemCase(_maxVideoCardDimensions, _dimensions, _supportedMotherBoardFormFactors);
    }
}