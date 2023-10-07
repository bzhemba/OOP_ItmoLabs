namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.HullExceptions;

public class HullAlreadyDestroyed : HullException
{
    public HullAlreadyDestroyed(string message)
        : base(message)
    {
    }

    public HullAlreadyDestroyed()
    {
    }

    public HullAlreadyDestroyed(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}