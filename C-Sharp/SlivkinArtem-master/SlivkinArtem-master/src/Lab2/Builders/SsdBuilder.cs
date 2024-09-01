using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SsdBuilder
{
    private Capacity? _capacity; 
    private Speed? _maxSpeed;
    private PowerConsumption? _ssdPowerConsumption;
    
    public SsdBuilder SetCapacity(Capacity? capacity)
    {
        ArgumentNullException.ThrowIfNull(capacity);
        this._capacity = capacity;
        return this;
    }
    
    public SsdBuilder SetMaxSpeed(Speed? maxSpeed)
    {
        ArgumentNullException.ThrowIfNull(maxSpeed);
        this._maxSpeed = maxSpeed;
        return this;
    }
    
    public SsdBuilder SetPowerConsumption(PowerConsumption? ssdPowerConsumption)
    {
        ArgumentNullException.ThrowIfNull(ssdPowerConsumption);
        this._ssdPowerConsumption = ssdPowerConsumption;
        return this;
    }

    public Ssd Build()
    {
        return new Ssd(_capacity, _ssdPowerConsumption, _maxSpeed);
    }
}