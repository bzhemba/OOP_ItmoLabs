using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Augur : ISpaceShip
{
    private const int Weight = 70;
    private const int Coefficient = 10;
    private const int StartingFuel = 300;
    private readonly IReadOnlyCollection<Deflector> _deflectors;
    private readonly Hull _hull;

    public Augur(IReadOnlyCollection<Deflector> deflectors, Hull hull, IReadOnlyCollection<Engine> engines)
    {
        CheckDeflectors(deflectors);
        CheckEngines(engines);
        CheckHull(hull);
        _deflectors = deflectors;
        _hull = hull;
        Engines = engines;
        StartTheEngines();
    }

    public IReadOnlyCollection<Engine> Engines { get; }
    public string Name { get; } = NameOfSpaceShip.Augur.ToString();

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
        foreach (DeflectorClassThree deflector in _deflectors.Where(deflector => deflector.IsOn))
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

    public virtual bool CollisionWithAntimatterFlares()
    {
        if (_deflectors.Where(d => d is { IsOn: true, HasPhotonModification:
                true }).Cast<DeflectorClassThree>().Any(deflector => deflector.ReflectAntimatterFlare()))
        {
            return true;
        }

        return false;
    }

    public virtual bool CollisionWithSpaceWhale()
    {
        if (_deflectors.Where(d => d.IsOn).Cast<DeflectorClassThree>().Any(deflector =>
                deflector.CanConfrontTheSpaceWhale()))
        {
            return true;
        }

        return false;
    }

    public bool CollisionWithAsteroid(Asteroid? asteroid)
    {
        if (asteroid == null) return true;
        int damage = asteroid.DamagePoints;
        foreach (DeflectorClassThree deflector in _deflectors.Where(deflector => deflector.IsOn))
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

    public double ComputeSpeed()
    {
        int sum = Engines.Sum(engine => (int)engine.Power());

        return sum * Coefficient / Weight;
    }

    private void CheckHull(Hull hull)
    {
        bool hullIsValid = hull is HullClassThree;
        if (!hullIsValid)
        {
            throw new IncorrectFormatException($"Not the right type of hull. " +
                                               $"{Name} can have only Hull Class Three");
        }
    }

    private void CheckEngines(IReadOnlyCollection<Engine> engines)
    {
        bool allEnginesAreValid = engines.All(engine => engine is EngineClassE or JumpingEngineAlpha);
        if (!allEnginesAreValid)
        {
            throw new IncorrectFormatException($"Not the right type of all engines. " +
                                               $"{Name} can have only Engine Class E or Jumping Engine Alpha");
        }
    }

    private void CheckDeflectors(IReadOnlyCollection<Deflector> deflectors)
    {
        bool allDeflectorsAreValid = deflectors.All(deflector => deflector is DeflectorClassThree);
        if (!allDeflectorsAreValid)
        {
            throw new IncorrectFormatException($"Not the right type of all deflectors. " +
                                               $"{Name} can have only Deflector Class Three");
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