using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class RouteSegment
{
    public RouteSegment(Environment.Environment environment, Distance? range)
    {
        Environment = environment;
        Range = range;
    }

    public Environment.Environment Environment { get; private set; }
    public Distance? Range { get; } 
}