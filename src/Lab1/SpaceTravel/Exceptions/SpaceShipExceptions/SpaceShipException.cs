using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;

public class SpaceShipException : Exception
{
    public SpaceShipException(string message)
        : base(message)
    {
    }

    public SpaceShipException()
    {
    }

    public SpaceShipException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}