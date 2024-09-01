using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class VideoCard
{
    public VideoCard(
        Count? videoMemoryAmount, 
        Version? pciEVersion, 
        Frequency? chipFrequency, 
        PowerConsumption? videoCardPowerConsumption, 
        Dimensions? dimensions)
    {
        VideoMemoryAmount = videoMemoryAmount;
        PciEVersion = pciEVersion;
        ChipFrequency = chipFrequency;
        VideoCardPowerConsumption = videoCardPowerConsumption;
        Dimensions = dimensions;
    }

    public static VideoCardBuilder Builder => new VideoCardBuilder();
    
    public PowerConsumption? VideoCardPowerConsumption { get; private set; }
    public Dimensions? Dimensions { get; private set; }
    public Count? VideoMemoryAmount { get; }
    public Version? PciEVersion { get; }
    public Frequency? ChipFrequency { get; }
}