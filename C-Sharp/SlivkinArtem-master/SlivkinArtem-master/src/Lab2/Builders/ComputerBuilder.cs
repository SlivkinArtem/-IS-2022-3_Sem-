using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Records;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class ComputerBuilder
{
    private Cpu? _cpu;
    private MotherBoard? _motherBoard;
    private Bios? _bios;
    private Cooler? _cooler;
    private Hdd? _hdd;
    private Ram? _ram;
    private Ssd? _ssd;
    private SystemCase? _systemCase;
    private VideoCard? _videoCard;
    private WiFiAdapter? _wiFiAdapter;
    private PowerUnit? _powerUnit;
    private XmpProfile? _xmpProfile;
    
    public AddAssemblingStatus? AddAssemblingStatus { get; private set; } = new Success();

    public ComputerBuilder BuildWithCpu(Cpu? cpu)
    {
        ArgumentNullException.ThrowIfNull(cpu);
        MotherBoardAndCpuValidator.ValidateSockets(_motherBoard, cpu);
        this._cpu = cpu;
        return this;
    }
    
    public ComputerBuilder BuildWithMotherBoard(MotherBoard? motherBoard)
    {
        ArgumentNullException.ThrowIfNull(motherBoard);
        this._motherBoard = motherBoard;
        return this;
    }
    
    public ComputerBuilder BuildWithBios(Bios? bios)
    {
        ArgumentNullException.ThrowIfNull(bios);
        this._bios = bios;
        return this;
    }
    
    public ComputerBuilder BuildWithCooler(Cooler? cooler)
    {
        CoolerAndCpuValidator.ValidateTdp(_cpu, cooler);
        ArgumentNullException.ThrowIfNull(cooler);
        ArgumentNullException.ThrowIfNull(_cpu);
        ArgumentNullException.ThrowIfNull(cooler.Tdp);
        ArgumentNullException.ThrowIfNull(_cpu.Tdp);
        this._cooler = cooler;
        return this;
    }
    
    public ComputerBuilder BuildWithHdd(Hdd? hdd)
    {
        ArgumentNullException.ThrowIfNull(hdd);
        this._hdd = hdd;
        return this;
    }
    
    public ComputerBuilder BuildWithRam(Ram? ram)
    {
        ArgumentNullException.ThrowIfNull(ram);
        MotherBoardAndRamValidator.ValidateDdr(_motherBoard, ram);
        this._ram = ram;
        return this;
    }
    
    public ComputerBuilder BuildWithSsd(Ssd? ssd)
    {
        ArgumentNullException.ThrowIfNull(ssd);
        this._ssd = ssd;
        return this;
    }
    
    public ComputerBuilder BuildWithSystemCase(SystemCase? systemCase)
    {
        CoolerAndMotherBoardAndCaseValidator.ValidateCapacityOfCoolerWithMotherBoardInTheSystemCase(_motherBoard, _cooler, systemCase);
        ArgumentNullException.ThrowIfNull(_motherBoard);
        ArgumentNullException.ThrowIfNull(_cooler);
        ArgumentNullException.ThrowIfNull(systemCase);
        this._systemCase = systemCase;
        return this;
    }
    
    public ComputerBuilder BuildWithVideoCard(VideoCard? videoCard)
    {
        ArgumentNullException.ThrowIfNull(videoCard);
        this._videoCard = videoCard;
        return this;
    }
    
    public ComputerBuilder BuildWithWiFiAdapter(WiFiAdapter? wiFiAdapter)
    {
        ArgumentNullException.ThrowIfNull(wiFiAdapter);
        this._wiFiAdapter = wiFiAdapter;
        return this;
    }

    public ComputerBuilder BuildWithPowerUnit(PowerUnit? powerUnit)
    {
        ArgumentNullException.ThrowIfNull(powerUnit);
        this._powerUnit = powerUnit;
        return this;
    }
    
    public ComputerBuilder BuildWithXmpProfile(XmpProfile? xmpProfile)
    {
        ArgumentNullException.ThrowIfNull(xmpProfile);
        this._xmpProfile = xmpProfile;
        return this;
    }

    public Computer Build()
    {
        AssemblingValidator.ValidateRequiredСomponentsAvailability(_motherBoard, _cpu, _cooler, _systemCase, _powerUnit);
        AssemblingValidator.ValidateCpuVideoCoreAvailability(_cpu, _videoCard == null);
        AssemblingValidator.ValidateSsdOrHddAvailability(_ssd, _hdd);
        return new Computer(_cpu, _motherBoard, _bios, _cooler, _hdd, _ram, _ssd, _systemCase, _videoCard, _wiFiAdapter, _xmpProfile);
    }
}