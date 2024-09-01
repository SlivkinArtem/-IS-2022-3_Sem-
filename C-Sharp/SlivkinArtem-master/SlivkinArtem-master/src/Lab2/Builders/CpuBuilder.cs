using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class CpuBuilder
{
    private Frequency? _coresFrequency;
    private Count? _numberOfCores;
    private Socket? _socket;
    private Tdp? _tdp;
    private PowerConsumption? _cpuPowerConsumption;
    
    public CpuBuilder SetCoreClock(Frequency? coresFrequency)
    {
        ArgumentNullException.ThrowIfNull(coresFrequency);
        this._coresFrequency = coresFrequency;
        return this;
    }
    
    public CpuBuilder SetNumberOfCores(Count? numberOfCores)
    {
        ArgumentNullException.ThrowIfNull(numberOfCores);
        this._numberOfCores = numberOfCores;
        return this;
    }
    
    public CpuBuilder SetSocket(Socket? socket)
    {
        ArgumentNullException.ThrowIfNull(socket);
        this._socket = socket;
        return this;
    }
    
    public CpuBuilder SetTdp(Tdp? tdp)
    {
        ArgumentNullException.ThrowIfNull(tdp);
        this._tdp = tdp;
        return this;
    }
    
    public CpuBuilder SetCpuPowerConsumption(PowerConsumption? cpuPowerConsumption)
    {
        ArgumentNullException.ThrowIfNull(cpuPowerConsumption);
        this._cpuPowerConsumption = cpuPowerConsumption;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(_socket, _tdp, _cpuPowerConsumption, _coresFrequency, _numberOfCores);
    }   
}