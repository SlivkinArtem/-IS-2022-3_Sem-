using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class HddBuilder
{
    private Capacity? _capacity; 
    private PowerConsumption? _hddPowerConsumption;
    private Speed? _spindleSpeed;
    
    public HddBuilder SetCapacity(Capacity? capacity)
    {
        ArgumentNullException.ThrowIfNull(capacity);
        this._capacity = capacity;
        return this;
    }
    
    public HddBuilder SetHddPowerConsumption(PowerConsumption? hddPowerConsumption)
    {
        ArgumentNullException.ThrowIfNull(hddPowerConsumption);
        this._hddPowerConsumption = hddPowerConsumption;
        return this;
    }
    
    public HddBuilder SetSpindleSpeed(Speed? spindleSpeed)
    {
        ArgumentNullException.ThrowIfNull(spindleSpeed);
        this._spindleSpeed = spindleSpeed;
        return this;
    }

    public Hdd Build()
    {
        return new Hdd(_capacity, _hddPowerConsumption, _spindleSpeed);
    }
}