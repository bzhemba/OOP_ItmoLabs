using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Augur : ISpaceShip
{
    private List<DeflectorClass3> _deflectors = new() { new DeflectorClass3() };
    private readonly List<Engine> _engines = new() { new EngineE(1000), new JumpingEngineAlpha(1000) };
    private HullClass3 _hull = new();

    public void AddDeflector(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _deflectors.Add(new DeflectorClass3());
        }
    }

    public void CollisionWithMeteorite(Meteorites meteorite)
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
}