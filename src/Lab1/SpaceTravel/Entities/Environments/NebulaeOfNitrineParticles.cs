using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

public class NebulaeOfNitrineParticles : IEnvironment
{
     private readonly IReadOnlyCollection<SpaceWhale>? _spaceWhales;
     public NebulaeOfNitrineParticles(double distance, IReadOnlyCollection<SpaceWhale>? spaceWhale)
     {
          CheckDistance(distance);
          Distance = new Distance(distance);
          _spaceWhales = spaceWhale;
     }

     public Distance Distance { get; }
     public TravelResult PassingEnvironment(ISpaceShip spaceShip)
     {
          if (spaceShip == null) throw new NullObjectException($"No Space Ship to pass this environment");
          IReadOnlyCollection<Engine> checkEngines = spaceShip.Engines;
          bool hasEngineE = checkEngines.Any(engine => engine is EngineClassE);

          if (!hasEngineE)
          {
               return TravelResult.ShipDestruction;
          }

          if (_spaceWhales == null) return TravelResult.Success;
          for (int i = 0; i < _spaceWhales.Count; i++)
          {
               if (!spaceShip.CollisionWithSpaceWhale())
               {
                    return TravelResult.ShipDestruction;
               }
          }

          return TravelResult.Success;
     }

     private static void CheckDistance(double distance)
     {
          if (distance <= 0)
          {
               throw new IncorrectFormatException($"Distance must be a positive number");
          }
     }
}