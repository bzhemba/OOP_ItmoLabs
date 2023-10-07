using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Meridian : ISpaceShip
{
    private const int Weight = 34;
    private const int StartingFuel = 300;
    private readonly IReadOnlyCollection<Deflector> _deflectors;
    private readonly Hull _hull;
    private bool _antinitrineEmitterIsON = true;
    public Meridian(IReadOnlyCollection<Deflector> deflectors, Hull hull, IReadOnlyCollection<Engine> engines)
    {
        CheckDeflectors(deflectors);
        CheckEngines(engines);
        CheckHull(hull);
        _deflectors = deflectors;
        _deflectors = deflectors;
        _hull = hull;
        Engines = engines;
        StartTheEngines();
    }

    public IReadOnlyCollection<Engine> Engines { get; }
    public string Name { get; } = NameOfSpaceShip.Meridian.ToString();

    public void AddPhotonDeflector()
    {
        Deflector firstTurnedOnDeflector =
            _deflectors.First(deflector => deflector is { IsOn: true, HasPhotonModification: false });
        firstTurnedOnDeflector.AddPhotonModification();
    }

    public bool CollisionWithMeteorite(Meteorite? meteorite)
    {
        if (meteorite == null) return true;
        int damage = meteorite.DamagePoints;
        foreach (DeflectorClassTwo deflector in _deflectors.Where(d => d.IsOn).Cast<DeflectorClassTwo>())
        {
            int remainedDamage = deflector.GetRemainedDamage(damage);
            if (remainedDamage != 0)
            {
                damage = remainedDamage;
            }
            else
            {
                damage = 0;
                break;
            }
        }

        if (damage != 0)
        {
            int hitPoints = _hull.GetRemainedDamage(damage);
            if (hitPoints < 0)
            {
                return false;
            }
        }

        return true;
    }

    public bool CollisionWithAntimatterFlares()
    {
        if (_deflectors.Where(d => d is { IsOn: true, HasPhotonModification:
                true }).Cast<DeflectorClassTwo>().Any(deflector => deflector.ReflectAntimatterFlare()))
        {
            return true;
        }

        return false;
    }

    public bool CollisionWithSpaceWhale()
    {
        if (_antinitrineEmitterIsON)
        {
            return true;
        }

        return false;
    }

    public bool CollisionWithAsteroid(Asteroid? asteroid)
    {
        if (asteroid == null) return true;
        int damage = asteroid.DamagePoints;
        foreach (DeflectorClassTwo deflector in _deflectors.Where(d => d.IsOn).Cast<DeflectorClassTwo>())
        {
            int remainedDamage = deflector.GetRemainedDamage(damage);
            if (remainedDamage != 0)
            {
                damage = remainedDamage;
            }
            else
            {
                damage = 0;
                break;
            }
        }

        if (damage != 0)
        {
            int hitPoints = _hull.GetRemainedDamage(damage);
            if (hitPoints < 0)
            {
                return false;
            }
        }

        return true;
    }

    public void AntinitrineEmitterON()
    {
        _antinitrineEmitterIsON = true;
    }

    public void AntinitrineEmitterOFF()
    {
        _antinitrineEmitterIsON = false;
    }

    public double ComputeSpeed()
    {
        const int coefficient = 10;
        int sum = Engines.Sum(engine => (int)engine.Power());

        return sum * coefficient / Weight;
    }

    private void CheckHull(Hull hull)
    {
        bool hullIsValid = hull is HullClassTwo;
        if (!hullIsValid)
        {
            throw new IncorrectFormatException($"Not the right type of hull. " +
                                               $"{Name} can have only Hull Class Two");
        }
    }

    private void CheckEngines(IReadOnlyCollection<Engine> engines)
    {
        bool allEnginesAreValid = engines.All(engine => engine is EngineClassE);
        if (!allEnginesAreValid)
        {
            throw new IncorrectFormatException($"Not the right type of all engines. " +
                                               $"{Name} can have only Engine Class E");
        }
    }

    private void CheckDeflectors(IReadOnlyCollection<Deflector> deflectors)
    {
        bool allDeflectorsAreValid = deflectors.All(deflector => deflector is DeflectorClassTwo);
        if (!allDeflectorsAreValid)
        {
            throw new IncorrectFormatException($"Not the right type of all deflectors. " +
                                               $"{Name} can have only Deflector Class Two");
        }
    }

    private void StartTheEngines()
    {
        foreach (Engine engine in Engines)
        {
            engine.AddFuel(StartingFuel);
            engine.StartingEngine();
        }
    }
}