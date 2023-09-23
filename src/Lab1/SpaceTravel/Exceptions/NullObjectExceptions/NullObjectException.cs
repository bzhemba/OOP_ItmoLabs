using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;

public class NullObjectException : Exception
{
    public NullObjectException(string message)
        : base(message)
    {
    }

    public NullObjectException()
    {
    }

    public NullObjectException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}