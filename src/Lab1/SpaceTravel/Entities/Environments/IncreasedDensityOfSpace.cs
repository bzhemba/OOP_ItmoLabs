using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EnvironmentExceptions;
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

    public bool PassingEnvironment(ISpaceShip spaceShip)
    {
        if (spaceShip == null || _subspaceChannels == null)
            throw new NullObjectException($"No Space Ship to pass this environment");
        IReadOnlyCollection<Engine> checkEngines = spaceShip.Engines;
        bool allChannelsValid = _subspaceChannels.All(channel =>
        {
            bool engineValid = checkEngines.Any(engine =>
                engine.TypeOfEngine == TypeOfEngine.Jumping && engine.JumpRange >= channel?.Length);
            if (!engineValid)
            {
                throw new EnvironmentMismatchException($"This spaceship is not suitable for this environment");
            }

            if (channel.AntimatterFlares == null) return true;
            for (int i = 0; i < channel.AntimatterFlares.Count; i++)
            {
                spaceShip.CollisionWithAntimatterFlares();
            }

            return true;
        });
        return allChannelsValid;
    }
}
