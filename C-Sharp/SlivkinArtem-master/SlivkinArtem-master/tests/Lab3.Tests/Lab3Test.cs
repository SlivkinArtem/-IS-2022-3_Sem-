using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Mocking;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Lab3Test
{
    [Fact]
    public void UnReadStatus()
    {
        var message = new Message("sms", "kek", Priority.Low);
        var user = new User();
        var userAdressee = new ProxyAdressee(new UserAdressee(user), Priority.Low);

        var topic = new Topic(new TopicName("ok"), userAdressee, message);
        topic.Send();
        ArgumentNullException.ThrowIfNull(user.Messages);
        Assert.False(User.CheckMessageStatus(user.Messages.FirstOrDefault()));
    }

    [Fact]
    public void ChangeStatus()
    {
        var message = new Message("sms", "kek", Priority.Low);
        var user = new User();
        var userAdressee = new ProxyAdressee(new UserAdressee(user), Priority.Low);

        var topic = new Topic(new TopicName("ok"), userAdressee, message);
        topic.Send();
        user.MarkMessageAsRead(0);
        ArgumentNullException.ThrowIfNull(user.Messages);
        Assert.True(User.CheckMessageStatus(user.Messages.FirstOrDefault()));
    }

    [Fact]
    public void MarkAsReadWhenAlreadyRead()
    {
        var message = new Message("sms", "kek", Priority.Low);
        var user = new User();
        var userAdressee = new ProxyAdressee(new UserAdressee(user), Priority.Low);

        var topic = new Topic(new TopicName("ok"), userAdressee, message);
        topic.Send();
        ArgumentNullException.ThrowIfNull(user.Messages);
        user.MarkMessageAsRead(0);
        MessageException exception = Assert.Throws<MessageException>(() =>
        {
            user.MarkMessageAsRead(0);
        });
        Assert.Equal("Message is already read", exception.Message);
    }

    [Fact]
    public void IncompetiblePriority()
    {
        var message = new Message("sms", "kek", Priority.High);
        var user = new User();
        var userAdressee = new MockProxyAdressee(new UserAdressee(user), Priority.Low);

        var topic = new Topic(new TopicName("ok"), userAdressee, message);
        topic.Send();
        ArgumentNullException.ThrowIfNull(user.Messages);
        Assert.Equal(0, userAdressee.Counter);
    }

    [Fact]
    public void NiceLog()
    {
        var message = new Message("sms", "kek", Priority.Low);
        var user = new User();
        var userAdressee = new MockLoggerAdressee(new UserAdressee(user));

        var topic = new Topic(new TopicName("ok"), userAdressee, message);
        topic.Send();
        ArgumentNullException.ThrowIfNull(user.Messages);
        Assert.Equal(1, userAdressee.Counter);
    }

    [Fact]
    public void MoqMessenger()
    {
        var message = new Message("sms", "kek", Priority.Low);
        var user = new User();
        var messengerAdressee = new MockMessenger();

        var topic = new Topic(new TopicName("ok"), messengerAdressee, message);
        topic.Send();
        ArgumentNullException.ThrowIfNull(user.Messages);
        Assert.Equal(1, messengerAdressee.Counter);
    }
}