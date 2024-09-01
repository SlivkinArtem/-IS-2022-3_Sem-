using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class RamBuilder
{
    private Count? _amountOfAvailableMemory;
    private Frequency? _supportedJedecFrequency;
    private ICollection<XmpProfile>? _availableXmrProfiles;
    private FormFactor? _formFactor;
    private Ddr? _ddr;
    private PowerConsumption? _ramPowerConsumption;

    public RamBuilder SetAmountOfAvailableMemory(Count? amountOfAvailableMemory)
    {
        ArgumentNullException.ThrowIfNull(amountOfAvailableMemory);
        this._amountOfAvailableMemory = amountOfAvailableMemory;
        return this;
    }
    
    public RamBuilder SetSupportedJedecFrequency(Frequency? supportedJedecFrequency)
    {
        ArgumentNullException.ThrowIfNull(supportedJedecFrequency);
        this._supportedJedecFrequency = supportedJedecFrequency;
        return this;
    }
    
    public RamBuilder SetAvailableXmrProfiles(ICollection<XmpProfile>? availableXmrProfiles)
    {
        ArgumentNullException.ThrowIfNull(availableXmrProfiles);
        this._availableXmrProfiles = availableXmrProfiles;
        return this;
    }
    
    public RamBuilder SetFormFactor(FormFactor? formFactor)
    {
        ArgumentNullException.ThrowIfNull(formFactor);
        this._formFactor = formFactor;
        return this;
    }
    
    public RamBuilder SetDdr(Ddr? ddr)
    {
        ArgumentNullException.ThrowIfNull(ddr);
        this._ddr = ddr;
        return this;
    }
    
    public RamBuilder SetRamPowerConsumption(PowerConsumption? ramPowerConsumption)
    {
        ArgumentNullException.ThrowIfNull(ramPowerConsumption);
        this._ramPowerConsumption = ramPowerConsumption;
        return this;
    }

    public Ram Build()
    {
        return new Ram(_amountOfAvailableMemory, _supportedJedecFrequency, _availableXmrProfiles, _formFactor, _ramPowerConsumption, _ddr);
    }
}