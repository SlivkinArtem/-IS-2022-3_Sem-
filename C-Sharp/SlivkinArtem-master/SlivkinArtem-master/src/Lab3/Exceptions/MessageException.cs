using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessageException : Exception
{
    private MessageException(string message) 
        : base(message)
    {
    }

    private MessageException()
    {
    }

    private MessageException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }

    public static MessageException MessageIsAlreadyReadException()
    {
        return new MessageException("Message is already read");
    }
    
    public static MessageException InvalidIndexException()
    {
        return new MessageException("Invalid index.");
    }
}