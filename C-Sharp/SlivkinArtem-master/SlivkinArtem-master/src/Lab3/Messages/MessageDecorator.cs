using System;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageDecorator
{
    private Message _message;
    public MessageDecorator(Message? message)
    {
        _message = message ?? throw new ArgumentNullException(nameof(message));
        IsRead = false;
        Body = message.Body;
        Header = message.Header;
        Priority = message.Priority;
    }
    
    public string Body { get; }
    public string Header { get; }
    public Priority Priority { get; }
    public bool IsRead { get; private set; }
    public void MarkAsRead()
    {
        if (IsRead)
        {
            throw MessageException.MessageIsAlreadyReadException();
        }
        IsRead = true;
    }
}