using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Stella : SpaceShip
{
    private Engine _stellaEngine = new EngineC(1000);
    private JumpingEngine _jumpingStellaEngine = new JumpingEngineOmega(1000);
    private Deflector _stellaDeflector = new DeflectorClass2();
    private Hull _stellaHull = new HullClass2();
    private int _weight = 13;
    private int _height = 72;

    // еще должны быть масса-габаритные характеристики
    public Hull StellaHull
    {
        get => _stellaHull;
    }

    public Deflector StellaDeflector
    {
        get => _stellaDeflector;
    }

    public Engine StellaEngine
    {
        get => _stellaEngine;
    }

    public JumpingEngine StellaJumpingEngine
    {
        get => _jumpingStellaEngine;
    }
}