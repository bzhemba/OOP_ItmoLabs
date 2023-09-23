using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Augur : SpaceShip
{
    private Engine _augurEngine = new EngineE(1000);
    private Deflector _augurDeflector = new DeflectorClass3();
    private Hull _augurHull = new HullClass3();
    private int _weight = 130;
    private int _height = 100;

    public Hull AugurHull
    {
        get => _augurHull;
    }

    public Deflector AugurDeflector
    {
        get => _augurDeflector;
    }

    public Engine AugurEngine
    {
        get => _augurEngine;
    }
}