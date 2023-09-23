using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.HullExceptions;

public class HullException : Exception
{
    public HullException(string message)
        : base(message)
    {
    }

    public HullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public HullException()
    {
    }
}