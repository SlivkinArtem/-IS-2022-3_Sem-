using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Meteorite : Obstacle
{
    private const int BaseDamage = 50;
    private const string EnvironmentName = "Space";
    public Meteorite()
        : base(BaseDamage, new EnvironmentType(EnvironmentName))
    {
    }
}