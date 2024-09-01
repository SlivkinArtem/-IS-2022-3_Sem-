using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public abstract class Obstacle
{
    protected Obstacle(int damage, EnvironmentType getEnvironmentType)
    {
        GetDamage = damage;
        GetEnvironmentType = getEnvironmentType;
    }

    public int GetDamage { get; }
    public EnvironmentType GetEnvironmentType { get; }
}