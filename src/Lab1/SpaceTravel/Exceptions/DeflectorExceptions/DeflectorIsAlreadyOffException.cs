using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.DeflectorExceptions;

public class DeflectorIsAlreadyOffException : DeflectorException
{
    public DeflectorIsAlreadyOffException(string message)
        : base(message)
    {
    }

    public DeflectorIsAlreadyOffException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public DeflectorIsAlreadyOffException()
    {
    }
}