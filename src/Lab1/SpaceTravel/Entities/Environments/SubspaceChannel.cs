using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

public record SubspaceChannel(int Length, IReadOnlyCollection<AntimatterFlare>? AntimatterFlares);