using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Augur : ISpaceShip
{
    private List<DeflectorClass3> _deflectors = new() { new DeflectorClass3() };
    private Collection<Engine> _engines = new() { new EngineE(), new JumpingEngineAlpha() };
    private HullClass3 _hull = new();
    public Collection<Engine> Engine { get => _engines; }

    public void AddDeflector(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _deflectors.Add(new DeflectorClass3());
        }
    }

    public void CollisionWithMeteorite(Meteorite meteorite)
    {
        if (meteorite != null)
        {
            int damage = meteorite.DamagePoints;
            foreach (DeflectorClass3 deflector in _deflectors)
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

    public virtual void CollisionWithAntimatterFlares()
    {
        if (typeof(DeflectorClass3).IsAssignableFrom(typeof(ICanReflectAntimatter)))
        {
            foreach (DeflectorClass3 deflector in _deflectors)
            {
                if (deflector.IsOn)
                {
                    var reflectiveDeflector = deflector as ICanReflectAntimatter;
                    reflectiveDeflector?.ReflectAntimatterFlare();
                    break;
                }
            }
        }

        throw new SpaceCrewDestroyedException($"Space ship doesn't have a deflector with modification." +
                                              $"The ship's crew has been destroyed");
    }

    public virtual void CollisionWithSpaceWhale()
    {
        foreach (DeflectorClass3 deflector in _deflectors)
        {
            if (deflector.IsOn)
            {
                deflector.ConfrontTheSpaceWhale();
                break;
            }
        }

        throw new SpaceShipDestroyedException($"Space ship has been destroyed");
    }

    public void CollisionWithAsteroid(Asteroid asteroid)
    {
        if (asteroid != null)
        {
            int damage = asteroid.DamagePoints;
            foreach (DeflectorClass3 deflector in _deflectors)
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

    public Collection<Engine> CheckCompatibility()
    {
        return Engine;
    }
}