using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class EnvironmentType
{
    public EnvironmentType(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
    }

    public string Name { get; }

    public bool Equals(EnvironmentType? other)
    {
        if (other is null) return false;
        return ReferenceEquals(this, other) || Equals(Name, other.Name);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((EnvironmentType)obj);
    }

    public override int GetHashCode()
    {
        return Name?.GetHashCode(StringComparison.Ordinal) ?? 0;
    }
}