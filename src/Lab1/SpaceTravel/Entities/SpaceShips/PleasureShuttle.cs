using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class PleasureShuttle : ISpaceShip
{
    private readonly HullClass1 _hull = new();
    private readonly Collection<Engine> _engine = new() { new EngineC() };
    private int _weight = 21;
    private bool _antinitrineEmitterIsON;
    public PleasureShuttle()
    {
        foreach (Engine engine in _engine)
        {
            engine.AddFuel(300);
            engine.StartingEngine();
        }
    }

    public Collection<Engine> Engines { get => _engine; }
    public string Name { get; } = "Pleasure Shuttle";

    public void AddDeflector(int count)
    {
        throw new NullObjectException($"Pleasure shuttle doesn't have deflectors. You can't add new");
    }

    public void AddPhotonDeflector()
    {
        throw new NullObjectException($"Pleasure shuttle doesn't have deflectors. You can't add Photon Modification");
    }

    public void CollisionWithMeteorite(Meteorite? meteorite)
    {
        if (meteorite != null)
        {
            int damage = meteorite.DamagePoints;
            _hull.TakeDamage(damage);
        }
    }

    public void CollisionWithAntimatterFlares()
    {
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
            _hull.TakeDamage(damage);
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
            foreach (Engine engine in _engine)
            {
                sum += (int)engine.Power();
            }

            return sum * 10 / _weight;
        }
}