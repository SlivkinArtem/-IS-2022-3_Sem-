using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Distance
{
    private const int MinLength = 0;
    public Distance(int length)
    {
        ValidateLength(length);
        Length = length;
    }
    public int Length { get; }
    public bool Equals(Distance? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Length == other.Length;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Distance)obj);
    }

    public override int GetHashCode()
    {
        return Length.GetHashCode();
    }
    private static void ValidateLength(int length) // static
    {
        if (length < MinLength)
            throw new ArgumentException($"Distance length {length} should be greater than {MinLength}.");
    }
}