using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class AntimatterFlares : Obstacle
{
    private const int BaseDamage = 0;
    private const string EnvironmentName = "IncreaseDensityNebula";

    public AntimatterFlares()
        : base(BaseDamage, new EnvironmentType(EnvironmentName))
    {
    }
}