using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public interface ISpaceShip
{
    public string Name { get; }
    public Collection<Engine> Engines { get; }
    public void AddDeflector(int count);

    public void AddPhotonDeflector();

    public void CollisionWithMeteorite(Meteorite meteorite);

    public void CollisionWithAntimatterFlares();

    public void CollisionWithSpaceWhale();

    public void CollisionWithAsteroid(Asteroid asteroid);
    public Collection<Engine> CheckCompatibility();
    public int ComputeSpeed();
}