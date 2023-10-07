namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;

public class EngineLackOfFuelException : EngineException
{
    public EngineLackOfFuelException(string message)
        : base(message)
    {
    }

    public EngineLackOfFuelException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public EngineLackOfFuelException()
    {
    }
}