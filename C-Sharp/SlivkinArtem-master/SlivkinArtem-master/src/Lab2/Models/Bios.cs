using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Bios
{
    public Bios(IEnumerable<Cpu?> supportedCpus)
    {
        ArgumentNullException.ThrowIfNull(supportedCpus);
        SupportedCpus = supportedCpus;
    }
    public static BiosBuilder Builder => new BiosBuilder();
    public IEnumerable<Cpu?>? SupportedCpus { get; private set; }
}