using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class User : IUser
{
    private readonly Dictionary<Message, bool> _messages = new();

    public User(IList<UserAttributeBase> attributes)
    {
        Attributes = attributes;
    }

    public IList<UserAttributeBase> Attributes { get; }

    public IUser GetMessage(Message message)
    {
        _messages.Add(message, false);
        return this;
    }

    public bool MessageChecked(Message message)
    {
        return _messages.TryGetValue(message, out bool result)
            ? result
            : throw new NotFoundMessageException();
    }

    public IUser CheckMessage(Message message)
    {
        if (!_messages.TryGetValue(message, out bool result))
            throw new NotFoundMessageException();
        if (result)
            throw new MessageIsAlreadyCheckedException();
        _messages[message] = true;

        return this;
    }
}