using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class XmpProfileBuilder
{
    private Frequency? _frequency;
    
    public XmpProfileBuilder SetFrequency(Frequency? frequency)
    {
        ArgumentNullException.ThrowIfNull(frequency);
        this._frequency = frequency;
        return this;
    }

    public XmpProfile Build()
    {
        return new XmpProfile(_frequency);
    }
}