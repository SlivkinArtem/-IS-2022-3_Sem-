using Itmo.ObjectOrientedProgramming.Lab3.Adressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Topic
{
    public Topic(TopicName topicName, Adressee adressee, Message message)
    {
        TopicName = topicName;
        Adressee = adressee;
        Message = message;
    }
    
    public Adressee Adressee { get; }
    public TopicName TopicName { get; }
    public Message Message { get; }

    public void Send()
    {
        Adressee.Send(Message);
    }
}