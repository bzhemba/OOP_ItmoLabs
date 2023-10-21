using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.ComponentsExceptions;

public class MissingComponentsException : Exception
{
    public MissingComponentsException(string message)
        : base(message)
    {
    }

    public MissingComponentsException()
    {
    }

    public MissingComponentsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}