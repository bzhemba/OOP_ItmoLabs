using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    private readonly List<DeflectorClassTwo> _deflectors = new() { new DeflectorClassTwo() };
    private readonly HullClassTwo _hull = new();
    private readonly Collection<Engine> _engine = new() { new EngineClassE() };
    private bool _antinitrineEmitterIsON;
    public Meridian()
    {
        foreach (Engine engine in _engine)
        {
            engine.AddFuel(StartingFuel);
            engine.StartingEngine();
        }
    }

    public IReadOnlyCollection<Engine> Engines { get => _engine; }
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
}