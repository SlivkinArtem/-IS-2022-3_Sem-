using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class BiosBuilder 
{
    private List<Cpu?> _supportedCpus = new List<Cpu?>();
    
    public BiosBuilder AddCpu(Cpu? cpu)
    {
        ArgumentNullException.ThrowIfNull(cpu);
        _supportedCpus.Add(cpu);
        return this;
    }

    public Bios Build()
    {
        return new Bios(_supportedCpus);
    }
}