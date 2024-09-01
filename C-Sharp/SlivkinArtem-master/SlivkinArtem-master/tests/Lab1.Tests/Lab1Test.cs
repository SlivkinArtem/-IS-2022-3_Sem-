using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.HullDurabilities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Simulators;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Lab1Test
{
    [Fact]
    public void AvgurAndShuttleInIncreaseDensityNebula()
    {
        // Arrange
        Ship walkingShuttle = new WalkingShuttle(new HullDurability1(), null, null, new EngineTypeC(), null, SizeType.Small);
        Ship avgur = new Avgur(new HullDurability3(), new Deflector3(), new PhotonDeflector(), new EngineTypeE(), new AlphaJumpEngine(), SizeType.Big);

        RouteSegment routeSegment1 = new(new IncreaseDensityNebula(new List<Obstacle>()), new Distance(1500));
        Route route = new(new List<RouteSegment> { routeSegment1 });
        var ships = new Collection<Ship> { avgur, walkingShuttle };

        // Act
        Simulator simulator = new(ships, route);
        simulator.CalculateRoute();

        // Assert
        Assert.Null(simulator.BestByTime());
    }

    [Fact]
    public void AntimatterFlaresInIncreaseDensityNebula()
    {
        // Arrange
        Ship wacklassWithPhoton = new Wacklass(new HullDurability2(), new Deflector1(), new PhotonDeflector(), new EngineTypeE(), new GammaJumpEngine(), SizeType.Middle);
        Ship wacklass = new Wacklass(new HullDurability2(), new Deflector1(), null, new EngineTypeE(), new GammaJumpEngine(), SizeType.Middle);

        RouteSegment routeSegment1 = new(new IncreaseDensityNebula(new List<Obstacle> { new AntimatterFlares() }), new Distance(1500));
        Route route = new(new List<RouteSegment> { routeSegment1 });
        var ships = new Collection<Ship> { wacklass, wacklassWithPhoton };

        // Act
        Simulator simulator = new(ships, route);
        simulator.CalculateRoute();

        // Assert
        Assert.Equal(wacklassWithPhoton, simulator.BestByTime());
    }

    [Fact]
    public void WhaleInNitrineParticleNebula()
    {
        // Arrange
        Ship avgur = new Avgur(new HullDurability3(), new Deflector3(), new PhotonDeflector(), new EngineTypeE(), new AlphaJumpEngine(), SizeType.Big);
        Ship wacklass = new Wacklass(new HullDurability2(), new Deflector1(), null, new EngineTypeE(), new GammaJumpEngine(), SizeType.Middle);
        Ship meredian = new Meridian(new HullDurability2(), new Deflector2(), null, new EngineTypeE(), null, SizeType.Middle);

        RouteSegment routeSegment1 = new(new NitrineParticleNebula(new List<Obstacle> { new Whale() }), new Distance(500));
        Route route = new(new List<RouteSegment> { routeSegment1 });
        var ships = new Collection<Ship> { avgur, wacklass, meredian };

        // Act
        Simulator simulator = new(ships, route);
        simulator.CalculateRoute();

        // Assert
        Assert.True(simulator.SurvivedShips().Contains(avgur) && simulator.SurvivedShips().Contains(meredian));
    }

    [Fact]
    public void WacklassAndShuttleInNormalSpace()
    {
        // Arrange
        Ship walkingShuttle = new WalkingShuttle(new HullDurability1(), null, null, new EngineTypeC(), null, SizeType.Small);
        Ship wacklass = new Wacklass(new HullDurability2(), new Deflector1(), null, new EngineTypeE(), new GammaJumpEngine(), SizeType.Middle);

        RouteSegment routeSegment1 = new(new Space(new List<Obstacle> { }), new Distance(250));
        Route route = new(new List<RouteSegment> { routeSegment1 });
        var ships = new Collection<Ship> { wacklass, walkingShuttle };

        // Act
        Simulator simulator = new(ships, route);
        simulator.CalculateRoute();

        // Assert
        Assert.Equal(walkingShuttle, simulator.BestByFuel());
    }

    [Fact]
    public void AvgurAndStellaInIncreaseDensityNebula()
    {
        // Arrange
        Ship stella = new Stella(new HullDurability1(), new Deflector1(), null, new EngineTypeC(), new OmegaJumpEngine(), SizeType.Small);
        Ship avgur = new Avgur(new HullDurability3(), new Deflector3(), new PhotonDeflector(), new EngineTypeE(), new AlphaJumpEngine(), SizeType.Big);

        RouteSegment routeSegment1 = new(new IncreaseDensityNebula(new List<Obstacle> { }), new Distance(1000));
        Route route = new(new List<RouteSegment> { routeSegment1 });
        var ships = new Collection<Ship> { stella, avgur };

        // Act
        Simulator simulator = new(ships, route);
        simulator.CalculateRoute();

        // Assert
        Assert.Equal(stella, simulator.BestByTime());
    }

    [Fact]
    public void WacklassAndShuttleInNitrineParticleNebula()
    {
        // Arrange
        Ship walkingShuttle = new WalkingShuttle(new HullDurability1(), null, null, new EngineTypeC(), null, SizeType.Small);
        Ship wacklass = new Wacklass(new HullDurability2(), new Deflector1(), null, new EngineTypeE(), new GammaJumpEngine(), SizeType.Middle);

        RouteSegment routeSegment1 = new(new NitrineParticleNebula(new List<Obstacle> { }), new Distance(500));
        Route route = new(new List<RouteSegment> { routeSegment1 });
        var ships = new Collection<Ship> { wacklass, walkingShuttle };

        // Act
        Simulator simulator = new(ships, route);
        simulator.CalculateRoute();

        // Assert
        Assert.Equal(wacklass, simulator.BestByTime());
    }
}