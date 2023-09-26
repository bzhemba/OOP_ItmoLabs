using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Paths;

public class PathSection
{
    public PathSection(Space space, int distance)
    {
        Distance = distance;
        Environment = space;
    }

    public PathSection(NebulaeOfNitrineParticles nebulaeOfNitrineParticles, int distance)
    {
        Environment = nebulaeOfNitrineParticles;
        Distance = distance;
    }

    public PathSection(IncreasedDensityOfSpace increasedDensityOfSpace, int distance)
    {
        Environment = increasedDensityOfSpace;
        Distance = distance;
    }

    public int Distance { get; }
    public IEnvironment Environment { get; }
}