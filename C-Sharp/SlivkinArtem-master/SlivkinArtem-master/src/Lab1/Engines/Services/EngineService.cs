using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;

public class EngineService
{
    private Engine? _engine;
    private JumpEngine? _jumpEngine;
    public EngineService(Engine? engine, JumpEngine? jumpEngine)
    {
        if (engine is not null) _engine = engine;
        _jumpEngine = jumpEngine;
        ExpeditionSuccessStatus = true;
    }
    
    public bool ExpeditionSuccessStatus { get; private set; }

    public void Calculate(RouteSegment routeSegment)
    {
        ArgumentNullException.ThrowIfNull(routeSegment);
        Validate(routeSegment);
        switch (routeSegment.Environment)
        {
            case NitrineParticleNebula or Space:
                _engine?.CalculateTime(routeSegment.Range);
                _engine?.CalculateFuel(routeSegment.Range);
                break;
            case IncreaseDensityNebula when _jumpEngine is not null:
                _jumpEngine.CalculateTime(routeSegment.Range);
                _jumpEngine.CalculateGravitationFuel();
                break;
        }
    }

    private void Validate(RouteSegment routeSegment)
    {
        switch (routeSegment.Environment)
        {
            case NitrineParticleNebula:
            {
                if (_engine is not EngineTypeE) 
                    ExpeditionSuccessStatus = false;
                break;
            }
            case IncreaseDensityNebula:
            {
                if (_jumpEngine is null)
                    ExpeditionSuccessStatus = false;
                if (routeSegment.Range != null && _jumpEngine?.Range != null &&
                    _jumpEngine != null && _jumpEngine.Range.Length < routeSegment.Range.Length)
                    ExpeditionSuccessStatus = false;
                break;
            }
        }
    }
}