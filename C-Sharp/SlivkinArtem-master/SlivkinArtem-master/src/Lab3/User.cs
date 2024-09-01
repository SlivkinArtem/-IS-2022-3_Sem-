using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class User
{
    public ICollection<MessageDecorator> Messages { get; } = new List<MessageDecorator>();
    public static bool CheckMessageStatus(MessageDecorator? messageDecorator)
    {
        ArgumentNullException.ThrowIfNull(messageDecorator);
        return messageDecorator.IsRead;
    }

    public void AddMessage(Message message)
    {
        var decoratedMessage = new MessageDecorator(message);
        Messages.Add(decoratedMessage);
    }
    
    public void MarkMessageAsRead(int index)
    {
        MessageDecorator? message = Messages.ElementAtOrDefault(index);
        ArgumentNullException.ThrowIfNull(message);
        message.MarkAsRead();
    }
}