using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Asteroid : Obstacle
{
    private const int BaseDamage = 10;
    private const string EnvironmentName = "Space";
    public Asteroid()
        : base(BaseDamage, new EnvironmentType(EnvironmentName))
    {
    }
}