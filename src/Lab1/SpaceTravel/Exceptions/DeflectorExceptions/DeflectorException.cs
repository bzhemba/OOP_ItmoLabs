using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.DeflectorExceptions;

public class DeflectorException : Exception
{
    public DeflectorException(string message)
        : base(message)
    {
    }

    public DeflectorException()
    {
    }

    public DeflectorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}