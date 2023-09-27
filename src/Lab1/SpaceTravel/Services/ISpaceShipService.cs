using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

public interface ISpaceShipService
{
    double LaunchCost(EngineC? engine, int time);
    double LaunchCost(EngineE? engine, int time);
    double LaunchCost(JumpingEngineAlpha? engine, int time);
    double LaunchCost(JumpingEngineGamma? engine, int time);
    double LaunchCost(JumpingEngineOmega? engine, int time);
    double LaunchTotalCost(ISpaceShip? spaceShip, int time);
    string TheBestByPrice(Collection<ISpaceShip> spaceShips, int time);
    string TheBestForNebulaeOfNitrineParticles(Collection<ISpaceShip> spaceShips);
    string TheBestForInscreasedDensityOfSpace(Collection<ISpaceShip> spaceShips);
    string TheBestForSpace(Collection<ISpaceShip> spaceShips);
}