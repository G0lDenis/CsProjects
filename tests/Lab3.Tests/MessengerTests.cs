using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Filtering;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Receiver;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessengerTests
{
    [Fact]
    public void MessageMustBeDefinedAsNotCheckedWhenGetFirstlyByUserTest()
    {
        var message = new Message("Aboba", "Body of Aboba", 3);
        IUser user = new User(new List<UserAttributeBase>());

        bool result = user
            .GetMessage(message)
            .MessageChecked(message);

        Assert.False(result);
    }

    [Fact]
    public void MessageMustBeDefinedAsCheckedWhenUserCheckedItTest()
    {
        var message = new Message("Aboba", "Body of Aboba", 3);
        IUser user = new User(new List<UserAttributeBase>());

        bool result = user
            .GetMessage(message)
            .CheckMessage(message)
            .MessageChecked(message);

        Assert.True(result);
    }

    [Fact]
    public void MessageCheckingErrorMustBeThrownAfterDoubleCheckingMessage()
    {
        var message = new Message("Aboba", "Body of Aboba", 3);
        IUser user = new User(new List<UserAttributeBase>());

        user.GetMessage(message)
            .CheckMessage(message);

        Assert.Throws<MessageIsAlreadyCheckedException>(() => user.CheckMessage(message));
    }

    [Fact]
    public void MessageWithLowPriorityMustBeFilteredTest()
    {
        var message = new Message("Aboba", "Body of Aboba", 1);
        IReceiver finalReceiver = Substitute.For<IReceiver>();
        IReceiver filter = new FilteringReceiver(finalReceiver, 4);

        filter.ReceiveMessage(message);

        finalReceiver.Received(0).ReceiveMessage(message);
    }

    [Fact]
    public void LogMessageMustBeCaughtByLoggerTest()
    {
        var message = new Message("Aboba", "Body of Aboba", 1);
        IMessageLogger logger = Substitute.For<IMessageLogger>();
        IReceiver finalReceiver = Substitute.For<IReceiver>();
        IReceiver loggerReceiver = new LoggingReceiver(finalReceiver, logger);

        loggerReceiver.ReceiveMessage(message);

        logger.Received(1).Log(message);
    }

    [Fact]
    public void MessengerMustReturnMessageWithInfoTest()
    {
        var message = new Message("Aboba", "Body of Aboba", 1);
        IMessengerConsoleWriter messageWriter = Substitute.For<IMessengerConsoleWriter>();
        var messenger = new Messenger(messageWriter);
        string expectedText = "message: " + new MessageRenderer(message).Render();

        messenger.GetMessage(message);

        messageWriter.Received(1).WriteText(expectedText);
    }
}