using System;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class SystemException : Exception
{
    public SystemException(string message) 
        : base(message)
    {
    }

    public SystemException()
    {
    }

    public SystemException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }

    public static SystemException FileOfTheSameNameException()
    {
        return new SystemException("New name of the file is the same");
    }
    
    public static SystemException InvalidArgumentsCountException()
    {
        return new SystemException("Invalid count of arguments");
    }
}