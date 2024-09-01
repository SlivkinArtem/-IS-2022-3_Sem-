using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Records;
using Version = Itmo.ObjectOrientedProgramming.Lab2.Records.Version;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class WiFiAdapterBuilder
{
    private Version? _version;
    private Availability? _hasBluetoothModule;
    private Version? _pciEVersion;
    private PowerConsumption? _powerConsumption;

    public WiFiAdapterBuilder SetVersion(Version? version)
    {
        ArgumentNullException.ThrowIfNull(version);
        this._version = version;
        return this;
    }
    
    public WiFiAdapterBuilder SetBluetoothModule(Availability? hasBluetoothModule)
    {
        ArgumentNullException.ThrowIfNull(hasBluetoothModule);
        this._hasBluetoothModule = hasBluetoothModule;
        return this;
    }
    
    public WiFiAdapterBuilder SetPciEVersion(Version? pciEVersion)
    {
        ArgumentNullException.ThrowIfNull(pciEVersion);
        this._pciEVersion = pciEVersion;
        return this;
    }
    
    public WiFiAdapterBuilder SetPowerConsumption(PowerConsumption? powerConsumption)
    {
        ArgumentNullException.ThrowIfNull(powerConsumption);
        this._powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(_version, _hasBluetoothModule, _pciEVersion, _powerConsumption);
    }
}