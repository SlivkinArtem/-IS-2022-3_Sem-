using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class GammaJumpEngine : JumpEngine
{
    private const int GammaJumpEngineSpeed = 1;
    private const int GammaFuelContribution = 300;
    private static readonly Distance? GammaJumpEngineRange = new Distance(2000);
    public GammaJumpEngine()
        : base(GammaJumpEngineSpeed, GammaJumpEngineRange)
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
        TotalGravitationFuel += GammaFuelContribution;
    }
}