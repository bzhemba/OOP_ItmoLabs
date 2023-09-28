using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

public record SubspaceChannel(int Len, Collection<AntimatterFlare?>? Flares)
{
    public int Length { get; init; } = Len;
    public Collection<AntimatterFlare?>? AntimatterFlares { get; init; } = Flares;
}