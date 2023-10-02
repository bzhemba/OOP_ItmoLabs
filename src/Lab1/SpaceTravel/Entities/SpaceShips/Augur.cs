using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Augur : ISpaceShip
{
    private const int Weight = 70;
    private const int StartingFuel = 300;
    private List<DeflectorClass3> _deflectors = new() { new DeflectorClass3() };
    private HullClass3 _hull = new();
    private bool _antinitrineEmitterIsON;

    public Augur()
    {
        foreach (Engine engine in Engines)
        {
            engine.AddFuel(StartingFuel);
            engine.StartingEngine();
        }
    }

    public IReadOnlyCollection<Engine> Engines { get; } = new List<Engine> { new EngineE(), new JumpingEngineAlpha() };
    public string Name { get; } = "Augur";

    public void AddDeflector(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _deflectors.Add(new DeflectorClass3());
        }
    }

    public void AddPhotonDeflector()
    {
        foreach (DeflectorClass3 deflector in _deflectors)
        {
            if (deflector.IsOn)
            {
                deflector.AddPhotonModification();
            }
        }
    }

    public void CollisionWithMeteorite(Meteorite? meteorite)
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
            foreach (DeflectorClass3 deflector in _deflectors)
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

    public virtual void CollisionWithSpaceWhale()
    {
        if (_antinitrineEmitterIsON)
        {
            return;
        }

        foreach (DeflectorClass3 deflector in _deflectors)
        {
            if (deflector.IsOn)
            {
                if (deflector.ConfrontTheSpaceWhale())
                {
                    return;
                }
            }
        }

        throw new SpaceShipDestroyedException($"Space ship has been destroyed");
    }

    public void CollisionWithAsteroid(Asteroid? asteroid)
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

    public void AntinitrineEmitterON()
    {
        _antinitrineEmitterIsON = true;
    }

    public void AntinitrineEmitterOFF()
    {
        _antinitrineEmitterIsON = false;
    }

    public int ComputeSpeed()
    {
        int sum = 0;
        foreach (Engine engine in Engines)
        {
            sum += (int)engine.Power();
        }

        return sum * 10 / Weight;
    }
}