using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
public class WrongObstacleEnvironmentException : Exception
{
    public WrongObstacleEnvironmentException(string message) 
        : base(message)
    {
    }

    public WrongObstacleEnvironmentException()
    {
    }

    public WrongObstacleEnvironmentException(string message, System.Exception innerException) 
        : base(message, innerException)
    {
    }
}