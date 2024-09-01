using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class XmpProfile
{
    private Frequency? _frequency;

    public XmpProfile(Frequency? frequency)
    {
        _frequency = frequency;
    }

    public static XmpProfileBuilder Builder => new XmpProfileBuilder();
}