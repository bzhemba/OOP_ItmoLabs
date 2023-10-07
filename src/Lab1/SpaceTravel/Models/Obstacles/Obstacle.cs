using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

public class Obstacle
{
    protected Obstacle(int damagePoints)
    {
        if (damagePoints < 0)
        {
            throw new IncorrectFormatException($"Damage points can't be a negative number");
        }

        DamagePoints = damagePoints;
    }

    public int DamagePoints { get; init; }
}