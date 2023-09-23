namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;

public class SpaceShipDestroyedException : SpaceShipException
{
    public SpaceShipDestroyedException(string message)
        : base(message)
    {
    }

    public SpaceShipDestroyedException()
    {
    }

    public SpaceShipDestroyedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}