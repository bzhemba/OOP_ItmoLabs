using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Vaklas : ISpaceShip
{
    private List<DeflectorClass1> _deflectors = new() { new DeflectorClass1() };
    private HullClass2 _hull = new();
    private readonly List<Engine> _engines = new() { new EngineE(1000), new JumpingEngineGamma(1000) };

    public void AddDeflector(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _deflectors.Add(new DeflectorClass1());
        }
    }

    public void CollisionWithMeteorite(Meteorites meteorite)
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
        if (typeof(DeflectorClass1).IsAssignableFrom(typeof(ICanReflectAntimatter)))
        {
            foreach (DeflectorClass1 deflector in _deflectors)
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

    public void CollisionWithSpaceWhale()
    {
        throw new SpaceShipDestroyedException($"Space ship has been destroyed");
    }
}