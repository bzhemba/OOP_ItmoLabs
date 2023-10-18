using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.ComponentsExceptions;

public class IncompatibilityProblemException : Exception
{
    public IncompatibilityProblemException(string message)
        : base(message)
    {
    }

    public IncompatibilityProblemException()
    {
    }

    public IncompatibilityProblemException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}