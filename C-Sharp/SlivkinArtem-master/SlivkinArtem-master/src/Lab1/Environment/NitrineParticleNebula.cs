using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NitrineParticleNebula : Environment
{
    private const string EnvironmentName = "NitrineParticleNebula";
    public NitrineParticleNebula(ICollection<Obstacle> getObstacles) 
        : base(getObstacles, new EnvironmentType(EnvironmentName))
    {
    }
}