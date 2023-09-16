using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;

public class EngineException : Exception
{
    public EngineException()
    { }

    public EngineException(string message)
        : base(message)
    { }

    public EngineException(string message, Exception innerException)
        : base(message, innerException)
    { }
}