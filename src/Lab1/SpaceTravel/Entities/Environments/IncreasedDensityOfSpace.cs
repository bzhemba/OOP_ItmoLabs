using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EnvironmentExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
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
                _distance += subspaceChannel.Length;
            }
        }
    }

    public int Distance => _distance;

    public bool PassingEnvironment(ISpaceShip spaceShip)
    {
        if (spaceShip != null && _subspaceChannels != null)
        {
            Collection<Engine> checkEngines = spaceShip.CheckCompatibility();
            int f = 0;
            foreach (SubspaceChannel channel in _subspaceChannels)
            {
                foreach (Engine engine in checkEngines)
                {
                    if ((engine.GetType().IsAssignableFrom(typeof(JumpingEngineAlpha)) ||
                        engine.GetType().IsAssignableFrom(typeof(JumpingEngineGamma)) ||
                        engine.GetType().IsAssignableFrom(typeof(JumpingEngineOmega))) && (engine.JumpRange >= channel.Length))
                    {
                        f = 1;
                        break;
                    }
                }

                if (f == 0)
                {
                    throw new EnvironmentMismatchException($"This spaceship is not suitable for this environment");
                }

                spaceShip.CollisionWithAntimatterFlares();

                return true;
            }
        }

        throw new NullObjectException($"No Space Ship to pass this environment");
    }
}
