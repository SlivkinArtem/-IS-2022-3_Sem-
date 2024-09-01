using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
namespace Itmo.ObjectOrientedProgramming.Lab1.Simulators;

public class Simulator
{
    private IReadOnlyCollection<Ship> _ships;
    private Route _route;

    public Simulator(Collection<Ship> ships, Route route)
    {
        _ships = ships;
        _route = route;
    }

    public void CalculateRoute()
    {
        foreach (RouteSegment segment in _route.RouteSegmentsGet)
        {
            foreach (Ship ship in _ships)
            {
                foreach (Obstacle obstacle in segment.Environment.GetObstacles)
                {
                    ship.TakeDamage(obstacle);
                }
                ship.EngineService.Calculate(segment);
                ship.UpdateStats();
            }
        }
    }

    public Ship? BestByTime()
    {
        return _ships
            .Where(s => s is { ShipDestroyedStatus: false, EngineService.ExpeditionSuccessStatus: true }).MinBy(s => s.TotalTime);
    }

    public Ship? BestByFuel()
    {
        return _ships
            .Where(s => s is { ShipDestroyedStatus: false, EngineService.ExpeditionSuccessStatus: true }).MinBy(s => s.TotalPrice);
    }

    public IEnumerable<Ship> SurvivedShips()
    {
        return _ships
            .Where(s => s is { ShipDestroyedStatus: false, EngineService.ExpeditionSuccessStatus: true });
    }
}