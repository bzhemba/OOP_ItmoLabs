using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Vaklas : SpaceShip
{
    private Engine _vaklasEngine = new EngineE(1000);
    private JumpingEngine _jumpingVaklasEngine = new JumpingEngineGamma(1000);
    private Deflector _vaklasDeflector = new DeflectorClass1();
    private Hull _vaklasHull = new HullClass2();
    private int _weight = 25;
    private int _height = 64;

    // еще должны быть масса-габаритные характеристики
    public Hull VaklasHull
    {
        get => _vaklasHull;
    }

    public Deflector VaklasDeflector
    {
        get => _vaklasDeflector;
    }

    public Engine VaklasEngine
    {
        get => _vaklasEngine;
    }

    public JumpingEngine VaklasJumpingEngine
    {
        get => _jumpingVaklasEngine;
    }
}