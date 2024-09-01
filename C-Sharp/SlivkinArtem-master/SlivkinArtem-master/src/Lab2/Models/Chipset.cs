using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Chipset
{
    public Chipset(IEnumerable<Frequency> ramSupportedFrequency)
    {
        RamSupportedFrequency = new List<Frequency>(ramSupportedFrequency ?? throw new ArgumentNullException(nameof(ramSupportedFrequency))).AsReadOnly();
    }

    public IReadOnlyCollection<Frequency> RamSupportedFrequency { get; }
}