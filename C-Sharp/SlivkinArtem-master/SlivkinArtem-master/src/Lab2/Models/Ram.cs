using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Ram
{
    private readonly List<XmpProfile>? _availableXmrProfiles;
    public Ram(
        Count? amountOfAvailableMemory, 
        Frequency? supportedJedecFrequency, 
        IEnumerable<XmpProfile>? availableXmrProfiles, 
        FormFactor? formFactor,  
        PowerConsumption? ramPowerConsumption, 
        Ddr? ddr)
    {
        ArgumentNullException.ThrowIfNull(availableXmrProfiles);
        AmountOfAvailableMemory = amountOfAvailableMemory;
        SupportedJedecFrequency = supportedJedecFrequency;
        _availableXmrProfiles = new List<XmpProfile>(availableXmrProfiles);
        FormFactor = formFactor;
        RamPowerConsumption = ramPowerConsumption;
        Ddr = ddr;
    }

    public static RamBuilder Builder => new RamBuilder();
    
    public PowerConsumption? RamPowerConsumption { get; private set; }
    public Ddr? Ddr { get; }
    public Count? AmountOfAvailableMemory { get; }
    public Frequency? SupportedJedecFrequency { get; }
    public FormFactor? FormFactor { get; }
}