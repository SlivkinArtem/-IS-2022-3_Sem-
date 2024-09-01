using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class Engine
{
    protected Engine(int fuelConsumption, int speed, int startFuel)
    {
        FuelConsumption = fuelConsumption;
        Speed = speed;
        TotalTime = 0;
        TotalFuel = 0;
        StartFuel = startFuel;
    }
    
    public int StartFuel { get; }
    public int Speed { get; }
    public int FuelConsumption { get; }
    
    public int TotalTime { get; protected set; }
    public int TotalFuel { get; protected set; }

    public abstract void CalculateTime(Distance? distance);
    public abstract void CalculateFuel(Distance? distance);
}