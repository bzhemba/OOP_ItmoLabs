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

    public IncreasedDensityOfSpace(ICollection<SubspaceChannel>? subspaceChannels)
    {
        _subspaceChannels = subspaceChannels;
    }

    public bool PassingEnvironment(ISpaceShip spaceShip)
    {
        if (spaceShip != null)
        {
            Collection<Engine> checkEngines = spaceShip.CheckCompatibility();
            int f = 0;
            foreach (Engine engine in checkEngines)
            {
                if (engine.GetType().IsAssignableFrom(typeof(JumpingEngineAlpha)) ||
                      engine.GetType().IsAssignableFrom(typeof(JumpingEngineGamma)) || engine.GetType().IsAssignableFrom(typeof(JumpingEngineOmega)))
                {
                    f = 1;
                    break;
                }
            }

            if (f == 0)
            {
                throw new EnvironmentMismatchException($"This spaceship is not suitable for this environment");
            }

            if (_subspaceChannels is not null)
            {
                spaceShip.CollisionWithAntimatterFlares();
            }

            return true;
        }

        throw new NullObjectException($"No Space Ship to pass this environment");
    }
}
