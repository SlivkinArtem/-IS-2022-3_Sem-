using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineTypeC : Engine
{
    private const int CFuelConsumption = 5;
    private const int CSpeed = 10;
    private const int CStartFuel = 5;
    public EngineTypeC()
        : base(CFuelConsumption, CSpeed, CStartFuel)
    {
    }

    public override void CalculateTime(Distance? distance)
    {
        if (distance != null)
        {
            TotalTime += distance.Length / Speed;
        }
    }

    public override void CalculateFuel(Distance? distance)
    {
        if (distance != null)
        {
            TotalFuel += (distance.Length / CFuelConsumption * FuelConsumption) + StartFuel; // сколько плазмы хавает двигатель за 10 единиц пути
        }
    }
}