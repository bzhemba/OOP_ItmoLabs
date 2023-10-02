using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Paths;

public class PathSection
{
    public PathSection(IEnvironment space, int distance)
    {
        Distance = distance;
        Environment = space;
    }

    public int Distance { get; }
    public IEnvironment Environment { get; }
}