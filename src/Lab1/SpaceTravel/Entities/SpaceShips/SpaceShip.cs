using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class SpaceShip
{
    private readonly List<Deflector> _deflectors;
    private Hull _hull;
    private Engine _engine;
    private int _weight = 13;
    private int _height = 72;

    public SpaceShip(Hull hull, Engine engine, int weight, int height)
    {
        _hull = hull;
        _engine = engine;
        _weight = weight;
        _height = height;
        _deflectors = new List<Deflector>();
    }

    public virtual void CollisionWithMeteorit(Meteorites meteorite)
    {
        if (meteorite != null)
        {
            int damage = meteorite.DamagePoints;
            foreach (Deflector deflector in _deflectors)
            {
                if (deflector.IsOn)
                {
                    int remainedDamage = deflector.TakeDamage(damage);
                    if (remainedDamage != 0)
                    {
                        damage = remainedDamage;
                    }
                }
            }

            if (damage != 0)
            {
                _hull.TakeDamage(damage);
            }
        }
    }

    public virtual void CollisionWithAntimatterFlares(AntimatterFlares antimatterFlare)
    {
        if (antimatterFlare != null)
        {
            foreach (Deflector deflector in _deflectors)
            {
                if (deflector.IsOn)
                {
                    deflector.TakeAntimatterFlareDamage(antimatterFlare);
                }
            }
        }
    }

    public virtual void CollisionWithSpaceWhale(SpaceWhales spaceWhale)
    {
        if (meteorite != null)
        {
            int damage = meteorite.DamagePoints;
            foreach (Deflector deflector in _deflectors)
            {
                if (deflector.IsOn)
                {
                    int remainedDamage = deflector.TakeDamage(damage);
                    if (remainedDamage != 0)
                    {
                        damage = remainedDamage;
                    }
                }
            }

            if (damage != 0)
            {
                _hull.TakeDamage(damage);
            }
        }
    }
    
}