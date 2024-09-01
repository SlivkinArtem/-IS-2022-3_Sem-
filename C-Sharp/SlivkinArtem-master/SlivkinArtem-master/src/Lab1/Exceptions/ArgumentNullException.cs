using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ArgumentNullException : Exception
{
    public ArgumentNullException(string message) 
        : base(message)
    {
    }

    public ArgumentNullException()
    {
    }

    public ArgumentNullException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}