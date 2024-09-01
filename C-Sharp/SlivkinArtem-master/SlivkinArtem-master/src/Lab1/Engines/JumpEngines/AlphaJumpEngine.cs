using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.JumpEngines;

public class AlphaJumpEngine : JumpEngine
{
    private const int AlphaJumpEngineSpeed = 1;
    private const int AlphaFuelContribution = 10;
    private static readonly Distance? AlphaJumpEngineRange = new Distance(1000);
    public AlphaJumpEngine()
        : base(AlphaJumpEngineSpeed, AlphaJumpEngineRange)
    {
    }

    public override void CalculateTime(Distance? distance)
    {
        if (distance != null)
        {
            TotalTime += distance.Length / Speed;
        }
    }

    public override void CalculateGravitationFuel()
    {
        TotalGravitationFuel += AlphaFuelContribution;
    }
}