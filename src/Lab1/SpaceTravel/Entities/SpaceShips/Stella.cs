using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Stella : ISpaceShip
{
    private readonly Collection<Engine> _engines = new() { new EngineC(), new JumpingEngineOmega() };
    private readonly List<DeflectorClass1> _deflectors = new() { new DeflectorClass1() };
    private readonly HullClass1 _hull = new();
    private int _weight = 23;
    private bool _antinitrineEmitterIsON;
    public Stella()
    {
        foreach (Engine engine in _engines)
        {
            engine.AddFuel(300);
            engine.StartingEngine();
        }
    }

    public Collection<Engine> Engines { get => _engines; }
    public string Name { get; } = "Stella";

    public void AddDeflector(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _deflectors.Add(new DeflectorClass1());
        }
    }

    public void AddPhotonDeflector()
    {
        foreach (DeflectorClass1 deflector in _deflectors)
        {
            if (deflector.IsOn)
            {
                deflector.AddPhotonModification();
            }
        }
    }

    public void CollisionWithMeteorite(Meteorite meteorite)
    {
        if (meteorite != null)
        {
            int damage = meteorite.DamagePoints;
            foreach (DeflectorClass1 deflector in _deflectors)
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
            foreach (DeflectorClass1 deflector in _deflectors)
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

    public void CollisionWithAsteroid(Asteroid asteroid)
    {
        if (asteroid != null)
        {
            int damage = asteroid.DamagePoints;
            foreach (DeflectorClass1 deflector in _deflectors)
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

    public Collection<Engine> CheckCompatibility()
    {
        return Engines;
    }

    public int ComputeSpeed()
    {
        int sum = 0;
        foreach (Engine engine in _engines)
        {
            sum += (int)engine.Power();
        }

        return sum * 10 / _weight;
    }
}