using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Paths;

public class PathSection
{
    public PathSection(IEnvironment environment, double distance)
    {
        CheckDistance(distance);
        CheckEnvironment(environment);
        Distance = distance;
        Environment = environment;
    }

    public double Distance { get; }
    public IEnvironment Environment { get; }

    private static void CheckDistance(double distance)
    {
        if (distance <= 0)
        {
            throw new IncorrectFormatException($"Distance must be a positive number");
        }
    }

    private static void CheckEnvironment(IEnvironment environment)
    {
        if (environment == null)
        {
            throw new NullObjectException($"No environment to add to the path section");
        }
    }
}