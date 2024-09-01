using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.JumpEngines;

public class OmegaJumpEngine : JumpEngine
{
    private const int OmegaJumpEngineSpeed = 1;
    private const int OmegaFuelContribution = 100;
    private static readonly Distance? OmegaJumpEngineRange = new Distance(3000);

    public OmegaJumpEngine()
        : base(OmegaJumpEngineSpeed, OmegaJumpEngineRange)
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
        TotalGravitationFuel += OmegaFuelContribution;
    }
}