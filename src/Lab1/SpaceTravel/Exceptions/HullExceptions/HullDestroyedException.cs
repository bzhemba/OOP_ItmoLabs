namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.HullExceptions;

public class HullDestroyedException : HullException
{
    public HullDestroyedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public HullDestroyedException()
    {
    }

    public HullDestroyedException(string message)
        : base(message)
    {
    }
}