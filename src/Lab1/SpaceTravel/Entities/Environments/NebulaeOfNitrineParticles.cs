using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EnvironmentExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

public class NebulaeOfNitrineParticles : IEnvironment
{
     private IReadOnlyCollection<SpaceWhale>? _spaceWhales;
     private double _distance;
     public NebulaeOfNitrineParticles(double distance, IReadOnlyCollection<SpaceWhale>? spaceWhale)
     {
          CheckDistance(distance);
          _spaceWhales = spaceWhale;
          _distance = distance;
     }

     public double Distance { get; }
     public bool PassingEnvironment(ISpaceShip spaceShip)
     {
          if (spaceShip != null)
          {
               IReadOnlyCollection<Engine> checkEngines = spaceShip.Engines;
               bool hasEngineE = checkEngines.Any(engine => engine is EngineClassE);

               if (!hasEngineE)
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

     private static void CheckDistance(double distance)
     {
          if (distance <= 0)
          {
               throw new IncorrectFormatException($"Distance must be a positive number");
          }
     }
}