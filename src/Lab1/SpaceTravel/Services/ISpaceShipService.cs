using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

public interface ISpaceShipService
{
    double LaunchCost(Engine engine, int time);
    string TheBestByPrice(Collection<ISpaceShip> spaceShips, int time);
    string TheBestForNebulaeOfNitrineParticles(Collection<ISpaceShip> spaceShips);
    string TheBestForInscreasedDensityOfSpace(Collection<ISpaceShip> spaceShips);
    string TheBestForSpace(Collection<ISpaceShip> spaceShips);
    void GetReport(ISpaceShip spaceShip, double distance);
}