using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

public interface ISpaceShipService
{
    double LaunchCost(Engine engine, int time);
    ISpaceShip TheBestByPrice(Collection<ISpaceShip> spaceShips, int time);
    ISpaceShip TheBestForNebulaeOfNitrineParticles(Collection<ISpaceShip> spaceShips);
    ISpaceShip TheBestForInscreasedDensityOfSpace(Collection<ISpaceShip> spaceShips);
    ISpaceShip TheBestForSpace(Collection<ISpaceShip> spaceShips);
    void GetReport(ISpaceShip spaceShip, double distance);
}