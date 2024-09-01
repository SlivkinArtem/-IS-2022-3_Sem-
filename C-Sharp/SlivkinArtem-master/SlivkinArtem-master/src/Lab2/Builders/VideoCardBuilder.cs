using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Records;
using Version = Itmo.ObjectOrientedProgramming.Lab2.Records.Version;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class VideoCardBuilder
{
    private Count? _videoMemoryAmount;
    private Version? _pciEVersion;
    private Frequency? _chipFrequency;
    private PowerConsumption? _videoCardPowerConsumption;
    private Dimensions? _dimensions;
    
    public VideoCardBuilder SetVideoMemoryAmount(Count? videoMemoryAmount)
    {
        ArgumentNullException.ThrowIfNull(videoMemoryAmount);
        this._videoMemoryAmount = videoMemoryAmount;
        return this;
    }
    
    public VideoCardBuilder SetPciEVersion(Version? pciEVersion)
    {
        ArgumentNullException.ThrowIfNull(pciEVersion);
        this._pciEVersion = pciEVersion;
        return this;
    }
    
    public VideoCardBuilder SetChipFrequency(Frequency? chipFrequency)
    {
        ArgumentNullException.ThrowIfNull(chipFrequency);
        this._chipFrequency = chipFrequency;
        return this;
    }
    
    public VideoCardBuilder SetVideoCardPowerConsumption(PowerConsumption? videoCardPowerConsumption)
    {
        ArgumentNullException.ThrowIfNull(videoCardPowerConsumption);
        this._videoCardPowerConsumption = videoCardPowerConsumption;
        return this;
    }
    
    public VideoCardBuilder SetDimensions(Dimensions? dimensions)
    {
        ArgumentNullException.ThrowIfNull(dimensions);
        this._dimensions = dimensions;
        return this;
    }

    public VideoCard Build()
    {
        return new VideoCard(_videoMemoryAmount, _pciEVersion, _chipFrequency, _videoCardPowerConsumption, _dimensions);
    }
}