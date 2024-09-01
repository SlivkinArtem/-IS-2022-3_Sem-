using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class Route
{
    public Route(ICollection<RouteSegment> routeSegmentsGet)
    {
        RouteSegmentsGet = routeSegmentsGet;
    }
    public ICollection<RouteSegment> RouteSegmentsGet { get; private set; }
}