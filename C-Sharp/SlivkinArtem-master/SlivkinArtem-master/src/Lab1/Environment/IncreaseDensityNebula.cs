using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class IncreaseDensityNebula : Environment
{
    private const string EnvironmentName = "IncreaseDensityNebula";
    public IncreaseDensityNebula(ICollection<Obstacle> obstaclesGet) 
        : base(obstaclesGet, new EnvironmentType(EnvironmentName))
    {
    }
}