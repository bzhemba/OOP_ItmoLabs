using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

public interface IEnvironment
{
    public bool PassingEnvironment(ISpaceShip spaceShip);
}