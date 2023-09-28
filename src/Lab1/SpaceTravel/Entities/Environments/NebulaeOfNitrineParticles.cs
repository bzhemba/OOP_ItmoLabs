using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EnvironmentExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

public class NebulaeOfNitrineParticles : IEnvironment
{
     private Collection<SpaceWhale?>? _spaceWhales;
     private int _distance;
     public NebulaeOfNitrineParticles(int distance, Collection<SpaceWhale?>? spaceWhale)
     {
          _spaceWhales = spaceWhale;
          _distance = distance;
     }

     public int Distance => _distance;
     public bool PassingEnvironment(ISpaceShip spaceShip)
     {
          if (spaceShip != null)
          {
               Collection<Engine> checkEngines = spaceShip.CheckCompatibility();
               int f = 0;
               foreach (Engine engine in checkEngines)
               {
                    if (engine.GetType().IsAssignableFrom(typeof(EngineE)))
                    {
                         f = 1;
                         break;
                    }
               }

               if (f == 0)
               {
                    throw new EnvironmentMismatchException($"This spaceship is not suitable for this environment");
               }

               if (_spaceWhales != null)
               {
                    for (int i = 0; i < _spaceWhales.Count; i++)
                    {
                         spaceShip.CollisionWithSpaceWhale();
                    }
               }

               return true;
          }

          throw new NullObjectException($"No Space Ship to pass this environment");
     }
}