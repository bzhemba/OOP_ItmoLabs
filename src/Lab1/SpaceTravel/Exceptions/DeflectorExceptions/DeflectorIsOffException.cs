namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.DeflectorExceptions;

public class DeflectorIsOffException : DeflectorException
{
    public DeflectorIsOffException(string message)
        : base(message)
    {
    }

    public DeflectorIsOffException()
    {
    }

    public DeflectorIsOffException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}