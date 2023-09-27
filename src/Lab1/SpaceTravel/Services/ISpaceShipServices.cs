using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

public interface ISpaceShipServices
{
    public ISpaceShip GetTheBestOption(Augur? augur, Meridian? meridian, PleasureShuttle? pleasureShuttle, Stella? stella, int time);
}