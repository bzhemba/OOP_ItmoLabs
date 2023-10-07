namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;

public class EngineDoesntExistExeption : EngineException
{
    public EngineDoesntExistExeption(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public EngineDoesntExistExeption()
    {
    }

    public EngineDoesntExistExeption(string message)
        : base(message)
    {
    }
}