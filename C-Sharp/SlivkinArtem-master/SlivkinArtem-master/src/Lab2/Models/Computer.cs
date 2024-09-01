namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Computer
{
    public Computer(
        Cpu? cpu, 
        MotherBoard? motherBoard, 
        Bios? bios, 
        Cooler? cooler, 
        Hdd? hdd, 
        Ram? ram, 
        Ssd? ssd, 
        SystemCase? systemCase, 
        VideoCard? videoCard, 
        WiFiAdapter? wiFiAdapter, 
        XmpProfile? xmpProfile)
    {
        Cpu = cpu;
        MotherBoard = motherBoard;
        Bios = bios;
        Cooler = cooler;
        Hdd = hdd;
        Ram = ram;
        Ssd = ssd;
        SystemCase = systemCase;
        VideoCard = videoCard;
        WiFiAdapter = wiFiAdapter;
        XmpProfile = xmpProfile;
        PowerConsumption = cpu?.CpuPowerConsumption?.Watt + ram?.RamPowerConsumption?.Watt 
                                                                  + videoCard?.VideoCardPowerConsumption?.Watt 
                                                                  + ssd?.SsdPowerConsumption?.Watt 
                                                                  + hdd?.HddPowerConsumption?.Watt;
    }

    public Cpu? Cpu { get; }
    public MotherBoard? MotherBoard { get; }
    public Bios? Bios { get; }
    public Cooler? Cooler { get; }
    public Hdd? Hdd { get; }
    public Ram? Ram { get; }
    public Ssd? Ssd { get; }
    public SystemCase? SystemCase { get; }
    public VideoCard? VideoCard { get; }
    public WiFiAdapter? WiFiAdapter { get; }
    public XmpProfile? XmpProfile { get; }
    public int? PowerConsumption { get; }
}