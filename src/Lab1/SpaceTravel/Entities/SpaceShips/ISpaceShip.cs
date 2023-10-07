using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public interface ISpaceShip
{
    public IReadOnlyCollection<Engine> Engines { get; }

    public void AddPhotonDeflector();

    public bool CollisionWithMeteorite(Meteorite? meteorite);

    public bool CollisionWithAntimatterFlares();

    public bool CollisionWithSpaceWhale();

    public bool CollisionWithAsteroid(Asteroid? asteroid);
    public double ComputeSpeed();
}