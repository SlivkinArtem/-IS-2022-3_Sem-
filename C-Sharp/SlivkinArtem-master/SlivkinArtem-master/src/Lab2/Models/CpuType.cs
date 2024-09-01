using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record CpuType
{
    public CpuType(string type)
    {
        ArgumentNullException.ThrowIfNull(type);
        Type = type;
    }
    public string Type { get; init; }
}