namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;

public class SpaceCrewDestroyedException : SpaceShipException
{
    public SpaceCrewDestroyedException(string message)
        : base(message)
    {
    }

    public SpaceCrewDestroyedException()
    {
    }

    public SpaceCrewDestroyedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}