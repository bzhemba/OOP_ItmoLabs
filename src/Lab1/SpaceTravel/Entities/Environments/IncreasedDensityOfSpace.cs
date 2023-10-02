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
    private ICollection<SubspaceChannel>? _subspaceChannels;
    private int _distance;

    public IncreasedDensityOfSpace(ICollection<SubspaceChannel>? subspaceChannels)
    {
        _subspaceChannels = subspaceChannels;
        if (subspaceChannels != null)
        {
            foreach (SubspaceChannel subspaceChannel in subspaceChannels)
            {
                if (subspaceChannel != null) _distance += subspaceChannel.Length;
            }
        }
    }

    public int Distance => _distance;

    public bool PassingEnvironment(ISpaceShip spaceShip)
    {
        if (spaceShip != null && _subspaceChannels != null)
        {
            IReadOnlyCollection<Engine> checkEngines = spaceShip.Engines;
            bool allChannelsValid = _subspaceChannels.All(channel =>
            {
                bool engineValid = checkEngines.Any(engine =>
                    engine.TypeOfEngine == TypeOfEngine.Jumping && engine.JumpRange >= channel?.Length);
                if (!engineValid)
                {
                    throw new EnvironmentMismatchException($"This spaceship is not suitable for this environment");
                }

                if (channel.AntimatterFlares != null)
                {
                    for (int i = 0; i < channel.AntimatterFlares.Count; i++)
                    {
                        spaceShip.CollisionWithAntimatterFlares();
                    }
                }

                return true;
            });
            return allChannelsValid;
        }

        throw new NullObjectException($"No Space Ship to pass this environment");
    }
}
