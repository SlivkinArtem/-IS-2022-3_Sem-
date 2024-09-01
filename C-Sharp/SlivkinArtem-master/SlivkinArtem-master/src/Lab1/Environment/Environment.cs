using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;
public abstract class Environment
{
    private readonly EnvironmentType _environmentType;
    protected Environment(ICollection<Obstacle> getObstacles, EnvironmentType environmentType)
    {
        _environmentType = environmentType;
        ObstacleVerification(getObstacles);
        GetObstacles = getObstacles;
    }

    public ICollection<Obstacle> GetObstacles { get; private set; }

    private void ObstacleVerification(ICollection<Obstacle> obstacles)
    {
        if (obstacles.Any(x => !x.GetEnvironmentType.Equals(_environmentType))) 
            throw new WrongObstacleEnvironmentException("Wrong Obstacle");
    }
}