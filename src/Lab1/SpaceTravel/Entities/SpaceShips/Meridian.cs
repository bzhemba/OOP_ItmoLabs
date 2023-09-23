using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Meridian : SpaceShip
{
    private Engine _meridianEngine = new EngineE(1000);
    private Deflector _meridianDeflector = new DeflectorClass2();
    private Hull _meridianHull = new HullClass2();
    private int _weight = 28;
    private int _height = 78;

    // еще должен быть антинитринный излучатель и масса-габаритные характеристики
    public Hull MeridianHull
    {
        get => _meridianHull;
    }

    public Deflector MeridianDeflector
    {
        get => _meridianDeflector;
    }

    public Engine MeridianEngine
    {
        get => _meridianEngine;
    }
}