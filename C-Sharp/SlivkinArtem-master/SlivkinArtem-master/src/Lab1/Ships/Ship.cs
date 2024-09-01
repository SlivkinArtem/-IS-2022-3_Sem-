using System;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.HullDurabilities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public abstract class Ship
{
    private const int FuelPrice = 10;
    private const int GravitationFuelPrice = 100;
    private HullDurability _hullDurability;

    private Deflector? _deflector;

    private PhotonDeflector? _photonDeflector;

    private SizeType _size;
    private bool _antinitrineEmitter;
    
    protected Ship(HullDurability hullDurability, Deflector? deflector, PhotonDeflector? photonDeflector, Engine? engine, JumpEngine? jumpEngine, SizeType size, bool antinitrineEmitter)
    {
        _hullDurability = hullDurability;
        _deflector = deflector;
        _photonDeflector = photonDeflector;
        Engine = engine;
        JumpEngine = jumpEngine;
        _size = size;
        _antinitrineEmitter = antinitrineEmitter;
        if (deflector is null)
            TotalHp = _hullDurability.HP;
        else 
            TotalHp = deflector.HP + _hullDurability.HP;
        if (_photonDeflector is not null)
            TotalReflectorCharges = _photonDeflector.HP;
        EngineService = new EngineService(Engine, JumpEngine);
    }
    public EngineService EngineService { get; }
    public Engine? Engine { get; private set; }
    public JumpEngine? JumpEngine { get; private set; }
    public int TotalPrice { get; private set; }
    public int TotalTime { get; private set; }
    public int TotalFuel { get; private set; }
    public int TotalGravitationFuel { get; private set; }
    public int TotalHp { get; private set; }
    public int TotalReflectorCharges { get; private set; }
    public bool ShipDestroyedStatus { get; private set; }
    public void TakeDamage(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);
        switch (obstacle)
        {
            case Whale:
            {
                if (!_antinitrineEmitter)
                {
                    TotalHp -= obstacle.GetDamage;
                }
                break;
            }
            case Meteorite or Asteroid:
                TotalHp -= obstacle.GetDamage;
                break;
            case AntimatterFlares when _photonDeflector is not null && TotalReflectorCharges >= 1:
                TotalReflectorCharges--;
                break;
            case AntimatterFlares when _photonDeflector is null || TotalReflectorCharges == 0:
                ShipDestroyedStatus = true;
                break;
        }

        if (TotalHp <= 0)
        {
            ShipDestroyedStatus = true;
        }
    }

    public void UpdateStats()
    {
        if (Engine == null) return;
        if (JumpEngine is null)
        {
            TotalTime = Engine.TotalTime;
            TotalFuel = Engine.TotalFuel;
            TotalPrice = Engine.TotalFuel * FuelPrice;
        }
        else
        {
            TotalTime = JumpEngine.TotalTime + Engine.TotalTime;
            TotalFuel = Engine.TotalFuel;
            TotalGravitationFuel = JumpEngine.TotalGravitationFuel;
            TotalPrice = (Engine.TotalFuel * FuelPrice) + (TotalGravitationFuel * GravitationFuelPrice);
        }
    }
}