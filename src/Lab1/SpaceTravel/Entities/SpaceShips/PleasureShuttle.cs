using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class PleasureShuttle : SpaceShip
{
    private Engine _shuttleEngine = new EngineC(1000);
    private Hull _shuttleHull = new HullClass1();
    private int _weight = 12;
    private int _height = 50;

    // еще должны быть масса-габаритные характеристики
    public Hull ShuttleHull
    {
        get => _shuttleHull;
    }

    public Engine ShuttleEngine
    {
        get => _shuttleEngine;
    }
}