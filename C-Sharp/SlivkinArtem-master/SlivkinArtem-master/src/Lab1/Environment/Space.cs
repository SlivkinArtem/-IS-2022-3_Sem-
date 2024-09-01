using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class Space : Environment
{
    private const string EnvironmentName = "Space";
    public Space(ICollection<Obstacle> obstaclesGet) 
        : base(obstaclesGet, new EnvironmentType(EnvironmentName))
    {
    }
}