using Itmo.ObjectOrientedProgramming.Lab3.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message
{
    public Message(string body, string header, Priority priority)
    {
        Body = body;
        Header = header;
        Priority = priority;
    }

    public string Body { get; }
    public string Header { get; }
    public Priority Priority { get; }
}