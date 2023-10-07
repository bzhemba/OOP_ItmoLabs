using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

public class IncreasedDensityOfSpace : IEnvironment
{
    private readonly ICollection<SubspaceChannel>? _subspaceChannels;

    public IncreasedDensityOfSpace(ICollection<SubspaceChannel>? subspaceChannels)
    {
        _subspaceChannels = subspaceChannels;
        if (subspaceChannels == null) return;
        foreach (SubspaceChannel subspaceChannel in subspaceChannels)
        {
            if (subspaceChannel != null) Distance += subspaceChannel.Length;
        }
    }

    public double Distance { get; }

    public TravelResult PassingEnvironment(ISpaceShip spaceShip)
    {
        if (spaceShip == null || _subspaceChannels == null)
            throw new NullObjectException($"No Space Ship to pass this environment");
        IReadOnlyCollection<Engine> checkEngines = spaceShip.Engines;
        foreach (SubspaceChannel channel in _subspaceChannels)
        {
            bool isEngineJumping = checkEngines.Any(engine =>
                engine.TypeOfEngine == TypeOfEngine.Jumping);
            if (!isEngineJumping)
            {
                return TravelResult.ShipDestruction;
            }

            bool isEngineValid = checkEngines.Any(engine => engine.JumpRange >= channel?.Length);
            if (isEngineValid)
            {
                if (channel.AntimatterFlares == null) continue;
                for (int i = 0; i < channel.AntimatterFlares.Count; i++)
                {
                    if (!spaceShip.CollisionWithAntimatterFlares())
                    {
                        return TravelResult.CrewDeath;
                    }
                }
            }
            else
            {
                return TravelResult.LossOfShip;
            }
        }

        return TravelResult.Success;
    }
}
