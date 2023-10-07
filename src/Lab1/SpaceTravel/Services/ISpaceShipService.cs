using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

public interface ISpaceShipService
{
    double LaunchCost(Engine engine, int time);
    TheBestSpaceShip GeTheBestByPrice(Collection<ISpaceShip> spaceShips, int time);
    TheBestSpaceShip GetTheBestForNebulaeOfNitrineParticles(Collection<ISpaceShip> spaceShips);
    TheBestSpaceShip GetTheBestForInscreasedDensityOfSpace(Collection<ISpaceShip> spaceShips);
    TheBestSpaceShip GetTheBestForSpace(Collection<ISpaceShip> spaceShips);
    Report GetReport(ISpaceShip spaceShip, double distance);
}