﻿using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Common;

public class ShipException : Exception
{
    public ShipException()
        : base("Undefined")
    {
    }

    public ShipException(string message)
        : base(message)
    {
    }

    public ShipException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}