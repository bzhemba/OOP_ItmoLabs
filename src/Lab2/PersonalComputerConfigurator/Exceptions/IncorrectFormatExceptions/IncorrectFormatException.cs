using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

public class IncorrectFormatException : Exception
{
    public IncorrectFormatException(string message)
        : base(message)
    {
    }

    public IncorrectFormatException()
    {
    }

    public IncorrectFormatException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}