using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

public record SubspaceChannel(int Len, AntimatterFlare Flare)
{
    public int Length { get; init; } = Len;
    public AntimatterFlare? AntimatterFlare { get; init; } = Flare;
}