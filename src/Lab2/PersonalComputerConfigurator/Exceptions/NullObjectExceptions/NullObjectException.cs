using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;

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