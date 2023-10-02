using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class PleasureShuttle : ISpaceShip
{
    private const int Weight = 21;
    private const int StartingFuel = 300;
    private readonly HullClassOne _hull = new();
    private readonly Collection<Engine> _engine = new() { new EngineClassC() };
    private bool _antinitrineEmitterIsON;
    public PleasureShuttle()
    {
        foreach (Engine engine in _engine)
        {
            engine.AddFuel(StartingFuel);
            engine.StartingEngine();
        }
    }

    public IReadOnlyCollection<Engine> Engines { get => _engine; }
    public string Name { get; } = "Pleasure Shuttle";

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