using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

public interface ISpaceShipService
{
    double LaunchCost(Engine engine, int time);
    TheBestSpaceShip TheBestByPrice(Collection<ISpaceShip> spaceShips, int time);
    TheBestSpaceShip TheBestForNebulaeOfNitrineParticles(Collection<ISpaceShip> spaceShips);
    TheBestSpaceShip TheBestForInscreasedDensityOfSpace(Collection<ISpaceShip> spaceShips);
    TheBestSpaceShip TheBestForSpace(Collection<ISpaceShip> spaceShips);
    Report GetReport(ISpaceShip spaceShip, double distance);
}