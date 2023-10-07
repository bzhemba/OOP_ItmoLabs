using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EnvironmentExceptions;

public class EnvironmentMismatchException : Exception
{
    public EnvironmentMismatchException(string message)
        : base(message)
    {
    }

    public EnvironmentMismatchException()
    {
    }

    public EnvironmentMismatchException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}