using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class EnvironmentNullException : Exception
{
public EnvironmentNullException(string message) 
    : base(message)
{
}

public EnvironmentNullException()
{
}

public EnvironmentNullException(string message, Exception innerException) 
    : base(message, innerException)
{
}
}