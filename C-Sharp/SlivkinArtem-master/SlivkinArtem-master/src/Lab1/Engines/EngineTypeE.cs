using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineTypeE : Engine
{
    private const int EFuelConsumption = 60;
    private const int ESpeed = 5;
    private const int EStartFuel = 30;
    private const int SpeedUp = 50;
    public EngineTypeE()
        : base(EFuelConsumption, ESpeed, EStartFuel)
    {
    }
    public override void CalculateTime(Distance? distance)
    {
        if (distance != null)
            TotalTime += distance.Length / (Speed * distance.Length / SpeedUp); // distance / ср.скорость = time 
    }
    public override void CalculateFuel(Distance? distance)
    {
        if (distance != null)
        {
            TotalFuel += (distance.Length / EFuelConsumption * FuelConsumption) + StartFuel;
        }
    }
}