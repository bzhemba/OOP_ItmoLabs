namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;

public class СrewHasBeenDestroyedException : SpaceShipException
{
    public СrewHasBeenDestroyedException(string message)
        : base(message)
    {
    }

    public СrewHasBeenDestroyedException()
    {
    }

    public СrewHasBeenDestroyedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}