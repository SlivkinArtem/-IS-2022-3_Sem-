using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Whale : Obstacle
{
    private const int BaseDamage = 10;
    private const string EnvironmentName = "NitrineParticleNebula";
    public Whale() 
        : base(BaseDamage, new EnvironmentType(EnvironmentName))
    {
    }
}