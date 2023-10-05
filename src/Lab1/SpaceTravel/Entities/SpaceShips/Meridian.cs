using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Meridian : ISpaceShip
{
    private const int Weight = 34;
    private const int StartingFuel = 300;
    private IReadOnlyCollection<Deflector> _deflectors;
    private Hull _hull;
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
    public string Name { get; } = "Meridian";

    public void AddPhotonDeflector()
    {
        foreach (DeflectorClassTwo deflector in _deflectors)
        {
            if (deflector.IsOn)
            {
                deflector.AddPhotonModification();
                return;
            }
        }
    }

    public void CollisionWithMeteorite(Meteorite? meteorite)
    {
        if (meteorite != null)
        {
            int damage = meteorite.DamagePoints;
            foreach (DeflectorClassTwo deflector in _deflectors)
            {
                if (deflector.IsOn)
                {
                    int remainedDamage = deflector.TakeDamage(damage);
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
            }

            if (damage != 0)
            {
                _hull.TakeDamage(damage);
            }
        }
    }

    public void CollisionWithAntimatterFlares()
    {
            foreach (DeflectorClassTwo deflector in _deflectors)
            {
                if (deflector.IsOn && deflector.HasPhotonModification)
                {
                    if (deflector.ReflectAntimatterFlare())
                    {
                        return;
                    }
                }
            }

            throw new SpaceCrewDestroyedException($"Space ship doesn't have a deflector with modification." +
                                                  $"The ship's crew has been destroyed");
    }

    public void CollisionWithSpaceWhale()
    {
        if (_antinitrineEmitterIsON)
        {
            return;
        }

        throw new SpaceShipDestroyedException($"Space ship has been destroyed");
    }

    public void CollisionWithAsteroid(Asteroid? asteroid)
    {
        if (asteroid != null)
        {
            int damage = asteroid.DamagePoints;
            foreach (DeflectorClassTwo deflector in _deflectors)
            {
                if (deflector.IsOn)
                {
                    int remainedDamage = deflector.TakeDamage(damage);
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
            }

            if (damage != 0)
            {
                _hull.TakeDamage(damage);
            }
        }
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
        int sum = 0;
        int coeficent = 10;
        foreach (Engine engine in Engines)
        {
            sum += (int)engine.Power();
        }

        return sum * coeficent / Weight;
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