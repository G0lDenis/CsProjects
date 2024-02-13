using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IUser
{
    IList<UserAttributeBase> Attributes { get; }
    IUser GetMessage(Message message);

    bool MessageChecked(Message message);

    IUser CheckMessage(Message message);
}