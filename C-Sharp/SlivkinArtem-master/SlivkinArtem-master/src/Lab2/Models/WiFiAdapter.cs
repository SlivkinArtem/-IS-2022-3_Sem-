using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class WiFiAdapter
{
    public WiFiAdapter(
        Version? version, 
        Availability? hasBluetoothModule, 
        Version? pciEVersion, 
        PowerConsumption? powerConsumption)
    {
        Version = version;
        HasBluetoothModule = hasBluetoothModule;
        PciEVersion = pciEVersion;
        PowerConsumption = powerConsumption;
    }
    public Availability? HasBluetoothModule { get; }
    public PowerConsumption? PowerConsumption { get; }
    public Version? Version { get; }
    public Version? PciEVersion { get; }
}